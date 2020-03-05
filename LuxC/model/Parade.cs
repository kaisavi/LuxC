using ConsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    //Console size: 240x132
    class Parade : Drawable {
        public Path Path { get; set; } = Paths.demo;
        public List<List<Orb>> sections { get; private set; }

        private int speed = 12;

        public void update(float deltaTime) {

            if (sections.Count > 0) {
                checkForHeadCollision();
                advance(deltaTime);
            }
        }

        private void checkForHeadCollision() {
            for(int i = 0; i < sections.Count - 1; i++) {
                if(sections[i].Last().Progress >= sections[i + 1].First().Progress - 6) {
                    sections[i].Last().Mode.Equals(OrbMode.NORMAL);
                    sections[i].AddRange(sections[i + 1]);
                    sections.Remove(sections[i + 1]);
                }
            }
                
        }

        private void advance(float deltaTime) {

            for (int i = 0; i < sections.Count; i++) {
                List<Orb> section = sections[i];
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

                if (section.Exists(((Orb o) => { return o.Mode.Equals(OrbMode.TAIL); })) && section.Count > 0) {
                        section.Last().Progress += speed * deltaTime;
                }
                
            }



        }

        private void Pop()
        {
            sections.Last().Remove(sections.Last().Last());
             
        }

        private void DestroyRange(int section, int index, int range) {
            

            if(index == 0 && range == sections[section].Count) { //destroy all orbs in a section 
                sections[section].Clear();
                sections.RemoveAt(section);
            }
            else {

                if (index + range >= sections[section].Count - 1) { // destroy leading orbs and reassign head 
                    sections[section][index - 1].Mode = OrbMode.HEAD;
                    
                }
                else if (index == 0) { // destroy tailing orbs and reassign tail 
                    sections[section][index + range].Mode = OrbMode.TAIL;

                }
                else { // destroy some orbs and assign new head 
                    sections[section][index - 1].Mode = OrbMode.HEAD;

                }
                double newProgress = sections[section][index].Progress; //Where to locate the section of orbs after destruction 
                //Split into two sections
                sections.Insert(section+1,sections[section].Skip(range+index).ToList());
                sections[section] = sections[section].Take(index).ToList();
                if (sections[section].Count == 0) {
                    sections.RemoveAt(section);
                    return;
                }
                if (sections[section + 1].Count == 0)
                    sections.RemoveAt(section+1);
                sections[section].Last().Progress = newProgress;
            }
            //TODO: Recursive Destruction 
        }

        public override void Draw() {
            DrawPath();
            DrawOrbs();
            DrawDebug();
        }

        private void DrawDebug() {
            for (int i = sections.Count - 1; i >= 0; i--) {
                for (int j = sections[i].Count - 1; j >= 0; j--) {

                    engine.WriteText(new Point(26 * i, sections[i].Count - j),
                    $"{i}. {sections[i][j].Color.ToString()} {sections[i][j].Mode.ToString()} + {sections[i][j].Progress}",
                    15);
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
                    sections[section].Last().Progress += i == 0 ? 0 : 14;
                    sections[section].Insert(i, o);
                }

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
                if (i >= sections[section].Count()) {
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
