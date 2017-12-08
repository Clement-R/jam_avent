using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_Sequencer : MonoBehaviour {

    public uint wwiseEventIdSong = 0;
    public int playbackPosition;
    public float timeToMove;
    public Game8_NoteSpawner noteSpawner;

    private bool _isEnded;
    private List<NoteData> _allNotes = new List<NoteData>();

    [System.Serializable]
    public class NoteData
    {
        public float time;
        public int line;
        public bool done = false;
        public float length = 0.0f;

        public NoteData(float time, int line, float length)
        {
            this.time = time;
            this.line = line;
            this.length = length;
        }
    }

    void Start ()
    {
        _allNotes = EditorOnFireFileParser.EOFFileReader.getNotes();

        foreach (var item in _allNotes)
        {
            print(item.time + " / " + item.line);
        }

        wwiseEventIdSong = AkSoundEngine.PostEvent("Play_Game1_Music",
                                                   gameObject,
                                                   (uint)AkCallbackType.AK_EndOfEvent | (uint)AkCallbackType.AK_EnableGetSourcePlayPosition,
                                                   OnSoundEnd,
                                                   null);

        StartCoroutine(LaunchNotes());
	}

    void OnSoundEnd(object in_cookie, AkCallbackType in_type, object in_info)
    {
        if (in_type == AkCallbackType.AK_EndOfEvent)
        {
            _isEnded = true;
        }
    }

    IEnumerator LaunchNotes()
    {
        // Don't update Sequencer or launch notes if the song is paused (normal pause or rock'or'die pause)
        while (!_isEnded)
        {
            print("Hello");
            AkSoundEngine.GetSourcePlayPosition(wwiseEventIdSong, out playbackPosition);
            // "Optimization", just check notes that are in the near future, we don't need to check all notes each time
            var aroundNotes = _allNotes.FindAll(note => (note.time - timeToMove + 0.4f <= ((float)playbackPosition / 1000) + 2.0f) && !note.done);

            for (int i = 0; i < aroundNotes.Count; i++)
            {
                if ((aroundNotes[i].time - timeToMove + 0.4f) <= ((float)playbackPosition / 1000) && !aroundNotes[i].done)
                {
                    noteSpawner.LaunchNote(aroundNotes[i].line);
                    aroundNotes[i].done = true;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
