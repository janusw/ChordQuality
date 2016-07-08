﻿using System.Collections;
using System.ComponentModel;
using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public class MidiDataModel : INotifyPropertyChanged
    {
        private ArrayList _chords;
        private ushort _timing;
        private byte _minNote;
        private byte _maxNote;
        private int _transpose;
        private int _totalBars;
        private MidiTrack[] _tracks;
        private string _midiFileName;

        public ArrayList Chords
        {
            get { return _chords; }
            set
            {
                if (value == _chords)
                    return;

                _chords = value; 
                OnPropertyChanged("Chords");
            }
        }

        public MidiTrack[] Tracks
        {
            get { return _tracks; }
            set
            {
                if (value == _tracks)
                    return;

                _tracks = value;
                OnPropertyChanged("Tracks");
            }
        }

        public ushort Timing
        {
            get { return _timing; }
            set
            {
                if (value == _timing)
                    return;

                _timing = value; 
                OnPropertyChanged("Timing");
            }
        }

        public byte MinNote
        {
            get { return _minNote; }
            set
            {
                if (value == _minNote)
                    return;

                _minNote = value;
                OnPropertyChanged("MinNote");
            }
        }

        public byte MaxNote
        {
            get { return _maxNote; }
            set
            {
                if (value == _maxNote )
                    return;

                _maxNote = value; 
                OnPropertyChanged("MaxNote");
            }
        }

        public int Transpose
        {
            get { return _transpose; }
            set
            {
                if (value == _transpose)
                    return;

                _transpose = value;
                OnPropertyChanged("Transpose");
            }
        }

        public int TotalBars
        {
            get { return _totalBars; }
            set
            {
                if (value == _totalBars)
                    return;

                _totalBars = value;
                OnPropertyChanged("TotalBars");
            }
        }

        public string MidiFileName
        {
            get { return _midiFileName; }
            set
            {
                if (value == _midiFileName)
                    return;

                _midiFileName = value;
                OnPropertyChanged("MidiFileName");
            }
        }

        public MidiDataModel(MidiFile file)
        {
            MidiFileName = file.name;
            Chords = file.FindChords();
            Tracks = file.tracks;
            Timing = file.timing;
            MinNote = file.min_note;
            MaxNote = file.max_note;
            Transpose = file.transpose;
            TotalBars = file.bars;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
