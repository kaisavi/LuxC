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
        public List<List<Orb>> sections { get; private set; } = new List<List<Orb>>();

        private int speed = 80;

        public void update(float deltaTime) {

            if (sections.Count > 0) {
                checkForHeadCollision();
                advance(deltaTime);
            }
            if (sections.Count == 1 && sections[0].Count == 1)
                sections.Clear();

            if(speed > 16) {
                speed--;
            }
        }

        private void checkForHeadCollision() {
            for(int i = 0; i < sections.Count - 1; i++) {
                if(sections[i].Last().Progress >= sections[i + 1].First().Progress - 6) {
                    Orb o = sections[i].Last();
                    sections[i].Last().Mode.Equals(OrbMode.NORMAL);
                    sections[i].AddRange(sections[i + 1]);
                    sections.Remove(sections[i + 1]);
                    checkForConsecutives(i, o);
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
                        break;
                    }
                    updateDeltaPos(section, j);
                }

                if (section.Exists(((Orb o) => { return o.Mode.Equals(OrbMode.TAIL); })) && section.Count > 0) {
                     section.Last().Progress += speed * deltaTime;
                    
                }
                if (sections.Count > 1 && i != 0)
                    if (section.First().Color.Equals(sections[i - 1].Last().Color) || sections[i-1].Last().Color.Equals(OrbColor.NONE)) {
                    section.Last().Progress -= speed * 2 * deltaTime;
                    }
            }



        }

        private void updateDeltaPos(List<Orb> section, int j) {
            Point prevPos = section[j].Position;
            section[j].Position = Path.Points[Math.Max((int)Math.Floor(section[j].Progress), 0)];
            if (!prevPos.Equals(section[j].Position)) {
                section[j].dX = section[j].Position.X < prevPos.X ? -1 :
                            section[j].Position.X == prevPos.X ? 0 : 1;

                section[j].dY = section[j].Position.Y < prevPos.Y ? -1 :
                                section[j].Position.Y == prevPos.Y ? 0 : 1;
            }
        }

        private void Pop()
        {
            sections.Last().Remove(sections.Last().Last());
            if (sections.Last().Count != 0)
                sections.Last().Last().Mode = sections.Last().Last().Mode != OrbMode.TAIL ? OrbMode.HEAD : OrbMode.TAIL;
            else
                sections.Remove(sections.Last());
        }

        private void DestroyRange(int section, int index, int range) {
            

            if(index == 0 && range == sections[section].Count) { //destroy all orbs in a section 
                sections[section].Clear();
                sections.RemoveAt(section);
                return;
            }
            else if (index + range >= sections[section].Count) { // destroy leading orbs and reassign head 
                sections[section][index - 1].Mode = OrbMode.HEAD;

            }
            else if (index == 0) { // destroy tailing orbs and reassign tail 
                sections[section][index + range].Mode = sections[section].First().Mode;

            }
            else { // destroy some orbs and assign new head or keep tail 
                sections[section][index - 1].Mode = sections[section][index - 1].Mode.Equals(OrbMode.TAIL) ? OrbMode.TAIL : OrbMode.HEAD;

            }
            double newProgress = sections[section][index].Progress - 7; //Where to locate the section of orbs after destruction 
                                                                        //Split into two sections
            sections.Insert(section + 1, sections[section].Skip(range + index).ToList());
            sections[section] = sections[section].Take(index).ToList();
            if (sections[section].Count == 0) {
                sections.RemoveAt(section);
                return;
            }
            if (sections[section + 1].Count == 0)
                sections.RemoveAt(section + 1);
            else {
                sections[section + 1].Last().Progress -= 7;
            }
            sections[section].Last().Progress = newProgress;
    }

        public override void Draw() {
            DrawPath();
            DrawOrbs();
            //DrawDebug();
        }

        private void DrawDebug() {
            for (int i = sections.Count - 1; i >= 0; i--) {
                for (int j = sections[i].Count - 1; j >= 0; j--) {

                    engine.WriteText(new Point(26 * i, sections[i].Count - j),
                    $"{i}. {sections[i][j].Color.ToString()} {sections[i][j].Mode.ToString()}; {(int)sections[i][j].Progress}; {sections[i][j].dX}, {sections[i][j].dY} ",
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
            int index = sections[section].IndexOf(c);
            o.unregisterCollision();

            if(sections[section][index].dX == 1) {
                insert(section, o, sections[section].IndexOf(c) +
                    (o.Position.X > c.Position.X ? 1 : 0));
            } else
            if(sections[section][index].dX == -1) {
                insert(section, o, sections[section].IndexOf(c) +
                    (o.Position.X < c.Position.X ? 1 : 0));
            } else
            if(sections[section][index].dY == 1) {
                insert(section, o, sections[section].IndexOf(c) + 1);
            }
            else {
                insert(section, o, sections[section].IndexOf(c));
            }
        }

        private void insert(int section, Orb o, int i) {

                if (i == sections[section].Count ) { //Insert after head, and reassign head 
                    o.Mode = OrbMode.HEAD;
                    sections[section][i - 1].Mode = OrbMode.NORMAL;
                    o.Progress = sections[section][i - 1].Progress + 6;
                    sections[section].Add(o);
                }
                else if (i == 0) { // insert at tail 
                    if(sections[section][0].Mode.Equals(OrbMode.TAIL)) {
                    o.Mode = OrbMode.TAIL;
                    sections[section][0].Mode = OrbMode.NORMAL;
                }
                        
                    sections[section].Insert(0, o);
                }
                else { //Insert somewhere and push head forward 
                    o.Progress = sections[section][i].Progress;
                    o.Mode = OrbMode.NORMAL;
                    sections[section].Last().Progress += i == 0 ? 0 : 7;
                    sections[section].Insert(i, o);
                }

            checkForConsecutives(section,o);
        }


        public Parade() {
            sections.Add(new OrbGenerator().GenerateOrbs(35));
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
