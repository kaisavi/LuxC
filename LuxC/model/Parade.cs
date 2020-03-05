﻿using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    //Console size: 240x132
    class Parade : Drawable {
        public Path Path { get; set; } = new Path(new List<Point> {
            
            new Point(-10,75),
            
            new Point(75,76),
            new Point(200,75),
            new Point(100,12),
            new Point(125,12),
            new Point(125,12),
            new Point(200,12),
            
            new Point(250,12),
            
        });
        public List<List<Orb>> sections { get; private set; }
        private List<Orb> consalidatedSections;

        private int speed = 12;
        private int activeHead;

        public void update(float deltaTime) {

            if (sections.Count > 0) {
                checkForHeadCollision();
                advance(deltaTime);
            }
        }

        private void checkForHeadCollision() {
            for(int i = 0; i < sections.Count - 1; i++) {
                if(sections[i].Last().Progress <= sections[i + 1].First().Progress) {
                    sections[i].Last().Mode.Equals(OrbMode.NORMAL);
                    sections[i].AddRange(sections[i + 1]);
                    sections.Remove(sections[i + 1]);
                }
            }
                
        }

        private void advance(float deltaTime) {

            for (int i = 0; i < sections.Count; i++) {
                List<Orb> section = sections[i];
                if(section.Exists(((Orb o) => { return o.Mode.Equals(OrbMode.TAIL); }))) {

                    for (int j = section.Count - 1; j >= 0; j--) {
                        if (j != section.Count - 1)
                            section[j].Progress = section.Last().Progress - (7 * ((section.Count - 1) - j));

                        if (section[j].Progress >= Path.Length - 1) {
                            Pop();

                            if (section.Count != 0)
                                section.Last().Mode = section.Last().Mode != OrbMode.TAIL ? OrbMode.HEAD : OrbMode.TAIL;
                            else
                                sections.Remove(sections.Last());

                            break;
                        }
                        
                        section[j].Position = Path.Points[Math.Max((int)Math.Floor(section[j].Progress), 0)];
                    }


                    section.Last().Progress += speed * deltaTime;
                }
            }



        }

        private void Pop()
        {
            sections.Last().Remove(sections.Last().Last());
             
        }

        private void DestroyRange(int section, int index, int range) {
            

            if(index == 0 && range == sections[section].Count) {
                sections[section].Clear();
            }
            else {

                if (index + range >= sections[section].Count - 1)
                    sections[section][index - 1].Mode = OrbMode.HEAD;
                else if (index == 0) {
                    sections[section][index + range].Mode = OrbMode.TAIL;

                }
                else {
                    sections[section][index + range].Mode = OrbMode.STRAY;
                    sections[section][index - 1].Mode = OrbMode.HEAD;
                    sections[section][index - 1].registerCollision(sections[section]);

                }
                sections[section].RemoveRange(index, range);
            }
            //TODO: Recursive Destruction 
        }

        public override void Draw() {
            DrawPath();
            DrawOrbs();

            for (int i = sections.Count - 1; i >= 0; i--) {
                for(int j = sections[i].Count - 1; j >= 0; j--) {
                    engine.WriteText(new Point(0, sections.Count - i),
                    $"{i}. {sections[i][j].Color.ToString()} {sections[i][j].Mode.ToString()} + {sections[i][j].Progress}",
                    i == activeHead ? 7 : 15);


                }
                    
            }
        }

        private void DrawPath() {
            Path.Draw();
        }

        private void DrawOrbs() {
            foreach(List<Orb> section in sections)
                foreach (Orb orb in section) {
                orb.Draw();
            }
        }

        public void insert(Orb o) {
            int section;
            Orb c = (Orb)o.CollidingBodies[0];
            section = sections.FindIndex((List<Orb> s) => { return s.Contains(c); });
            o.unregisterCollision();
            insert(section, o, sections[section].IndexOf(c) + (o.Position.X > c.Position.X ? 1:0));
        }

        private void insert(int section, Orb o, int i) {
            // = Active head + 1: Determine if it is closer to the stray, or the head;
                // Insert after head, reassign head 
                // Insert before stray, reassign stray 
            // = Stray: Insert after stray, push next head 
            // > Stray: insert, push next head 
            // = Next head 

            //else { //insert somewhere before the active head 
            //if(i == activeHead + 1) {
            //    Console.WriteLine();
            //}
                if (i == sections[section].Count ) { //Insert after head, and reassign head 
                    o.Mode = OrbMode.HEAD;
                    sections[section][i - 1].Mode = OrbMode.NORMAL;
                    o.Progress = sections[section][i - 1].Progress + 6;
                    sections[section].Add(o);
                }
                else if (i == 0) { // insert at tail 
                    o.Mode = OrbMode.TAIL;
                    sections[section][0].Mode = OrbMode.NORMAL;
                    sections[section].Insert(0, o);
                }
                else { //Insert somewhere and push head forward 
                    o.Progress = sections[section][i].Progress;
                    o.Mode = OrbMode.NORMAL;
                    sections[section].Last().Progress += i == 0 ? 0 : 7;
                    sections[section].Insert(i, o);
                }
            //}
            checkForConsecutives(section,o);
        }


        public Parade() {
            sections = new List<List<Orb>> {
                new List<Orb> {
                           new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLACK),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE),
            new Orb(OrbColor.BLUE)
                }
            };
           // Orbs.Last().Progress = 60; 
            //Orbs[4].Mode = OrbMode.STRAY; 
            sections[0].Last().Mode = OrbMode.HEAD;
            sections[0].First().Mode = OrbMode.TAIL;
        }


        public void checkForConsecutives(int section, Orb o) {
            //TODO rewrite pretty much all of this 

            OrbColor color = o.Color;
            bool backSearching = true;
            int consecutives = 1;
            int consecutivesStart = 0;
            int i = sections[section].IndexOf(o)-1;
            while (backSearching) {
                if (i < 0) {
                    backSearching = false;
                    break;
                }
                if (sections[section][i].Color.Equals(color)) {
                    consecutives++;
                    i--;
                }
                else {
                    consecutivesStart = i + 1;
                    backSearching = false;
                }
                    
            }

            bool forwardSearching = true;
            i = sections[section].IndexOf(o)+1;
            
            while (forwardSearching) {
                if (i >= sections.Count()) {
                    forwardSearching = false;
                    break;
                }
                if(sections[section][i].Color.Equals(color)) {
                    consecutives++;
                    i++;
                }
                else {
                    forwardSearching = false;
                }
            }

            if(consecutives >= 3) {
                DestroyRange(section, consecutivesStart, consecutives);
            }
        }

    }

}
