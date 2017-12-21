using System;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EditorOnFireFileParser
{
    public class Game21_FileParser : MonoBehaviour
    {
        private void Start()
        {
            print(getNotes());
        }

        static public List<Game21_Sequencer.NoteData> getNotes()
        {
            {
                // Read file
                TextAsset asset = Resources.Load("notes_2 - Copie") as TextAsset;
                byte[] file = asset.bytes;
                // byte[] file = File.ReadAllBytes("Assets/EditorOnFireFileParser/Resources/notes_2.eof");

                // Get file header
                char[] fileHeader = (from header in file.Take(8) select Convert.ToChar(header)).ToArray();

                // Get chart properties
                ChartProperties chartProperties = new ChartProperties(file);

                // Get song properties
                SongProperties songProperties = new SongProperties(file);

                // Get chart data
                ChartData chartData = new ChartData(file, songProperties.endByteIndex);

                // Get tracks data
                TrackData tracks = new TrackData(file, chartData.endByteIndex);

                LegacyTrack t = tracks.tracks.OfType<LegacyTrack>().ElementAt(0);

                List<Game21_Sequencer.NoteData> notes = new List<Game21_Sequencer.NoteData>();

                foreach (var note in t.notes)
                {
                    // For each lane in this note (one "note" can be one note on each 2 lanes for Deadly Riff) we add a note to the sequencer
                    for (int i = 0; i < 2; i++)
                    {
                        if (note.lanes[i])
                        {
                            // Convert from millisecond to second
                            if (note.length <= 1)
                            {
                                notes.Add(new Game21_Sequencer.NoteData((float)note.position / 1000, i, 0.0f));
                            }
                            else
                            {
                                notes.Add(new Game21_Sequencer.NoteData((float)note.position / 1000, i, (float)note.length / 1000));
                            }

                        }
                    }
                }

                return notes;
            }
        }
    }
}