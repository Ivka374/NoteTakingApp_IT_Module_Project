using Manufaktura.Controls.Model;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.MajorAndMinor;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    class MusicViewModel : ViewModel
    {
        private Score data;

        public Score Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged(() => Data); }
        }


        public void LoadTestData()
        {
            #region For reference to music
            Score score = Score.CreateOneStaffScore(Clef.Treble, new MajorScale(Step.C, false));
            score.FirstStaff.Elements.Add(new Note(Pitch.C5, RhythmicDuration.Quarter));
            score.FirstStaff.Elements.Add(new Note(Pitch.B4, RhythmicDuration.Quarter));
            score.FirstStaff.Elements.Add(new Note(Pitch.C5, RhythmicDuration.Half));
            score.FirstStaff.Elements.Add(new Barline());
            Data = score;

            Staff secondStaff = new Staff();
            secondStaff.Elements.Add(Clef.Treble);
            secondStaff.Elements.Add(new Key(0));
            secondStaff.Elements.Add(new Note(Pitch.G4, RhythmicDuration.Whole));
            secondStaff.Elements.Add(new Barline());
            score.Staves.Add(secondStaff);

            score.Staves.Add(new Staff());
            score.ThirdStaff.Elements.Add(Clef.Tenor);
            score.ThirdStaff.Elements.Add(new Key(0));
            score.ThirdStaff.Elements.Add(new Note(Pitch.D4, RhythmicDuration.Half));
            score.ThirdStaff.Elements.Add(new Note(Pitch.E4, RhythmicDuration.Half));
            score.ThirdStaff.Elements.Add(new Barline());

            score.Staves.Add(new Staff());
            score.Staves[3].Elements.Add(Clef.Bass);    //0-based index
            score.Staves[3].Elements.Add(new Key(0));
            score.Staves[3].Elements.Add(new Note(Pitch.G3, RhythmicDuration.Half));
            score.Staves[3].Elements.Add(new Note(Pitch.C3, RhythmicDuration.Half));
            score.Staves[3].Elements.Add(new Barline());

            #endregion        
        }
    }
}
