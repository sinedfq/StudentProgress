using Avalonia.Media;
using ProgressTable.Models;
using ReactiveUI;
using System;
using System.Reactive;

namespace ProgressTable.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Student[] students;

        private SolidColorBrush checkColor(float num)
        {
            if (num < 1) return new SolidColorBrush(Colors.Red);
            if (num < 1.5) return new SolidColorBrush(Colors.Yellow);
            else return new SolidColorBrush(Colors.Green);
        }

        private void CheckAverage(Student[] students)
        {
            for (int i = 0; i < 4; i++)
            {
                sc_score[i] = 0;
            }
            for (int i = 0; i < students.Length; i++)
            {
                ScoreVisualSr += students[i].Visual;
                ScoreArchitectureSr += students[i].Architecture;
                ScoreNetworksSr += students[i].Networks;
                ScoreAverageSr += students[i].Average_Score;
            }
            ScoreVisualSr /= students.Length;
            ColorVisualSr = checkColor(ScoreVisualSr);
            ScoreArchitectureSr /= students.Length;
            ColorArchitectureSr = checkColor(ScoreArchitectureSr);
            ScoreNetworksSr /= students.Length;
            ColorNetworksSr = checkColor(ScoreNetworksSr);
            ScoreAverageSr /= students.Length;
            ColorAverageSr = checkColor(ScoreAverageSr);
        }

        public MainWindowViewModel()
        {
            AddStudent = ReactiveCommand.Create(() =>
            {
                if (newName != "")
                {
                    Student[] temp = students;
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = new Student { Name = newName, Visual = scores[0], Architecture = scores[1], Networks = scores[2] };
                    Students = temp;
                    NewName = "";
                    ScoreVisual = 0;
                    ScoreArchitecture = 0;
                    ScoreNetworks = 0;
                    CheckAverage(students);
                }
            });
            DeleteStudent = ReactiveCommand.Create(() =>
            {
                if (index < students.Length)
                {
                    Student[] temp = students;
                    for (int i = index; i < temp.Length - 1; i++)
                    {
                        temp[i] = temp[i + 1];
                    }
                    Array.Resize(ref temp, temp.Length - 1);
                    Students = temp;
                    Index = 5000;
                    CheckAverage(students);
                }
            });
            Save = ReactiveCommand.Create(() =>
            {
                Serializer<Student[]>.Save("data.dat", students);
            });
            Load = ReactiveCommand.Create(() =>
            {
                Students = Serializer<Student[]>.Load("data.dat");
                CheckAverage(students);
            });
            Students = new Student[]
            {
                new Student{Name="Попкова Дарья", Visual=0, Architecture=0, Networks=0 },
                new Student{Name="Рыбакова Арина", Visual=2, Architecture=2, Networks=2 },
                new Student{Name="Хухарев Денис", Visual=1, Architecture=1, Networks=1 },
                new Student{Name="Пожидаев Илья", Visual=1, Architecture=2, Networks=0 },
                new Student{Name="Стриков Илья", Visual=2, Architecture=2, Networks=2 },
                new Student{Name="Лазарев Семен ", Visual=1, Architecture=1, Networks=1 },
                new Student{Name="Махонин Павел", Visual=1, Architecture=2, Networks=0 },
                new Student{Name="Траханов Илья", Visual=2, Architecture=2, Networks=2 },
            
            };
            CheckAverage(students);

        }

        public Student[] Students
        {
            get => students;
            set => this.RaiseAndSetIfChanged(ref students, value);
        }

        public ReactiveCommand<Unit, Unit> Save { get; }
        public ReactiveCommand<Unit, Unit> Load { get; }
        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        public ReactiveCommand<Unit, Unit> DeleteStudent { get; }

        private ushort[] scores = { 0, 0, 0 };
        private string newName = "";
        private ushort index = 5000;
        private float[] sc_score = { 0, 0, 0, 0 };
        private SolidColorBrush[] colorBrush = new SolidColorBrush[4];
        public ushort Index { get => index; set => this.RaiseAndSetIfChanged(ref index, value); }
        public string NewName { get => newName; set => this.RaiseAndSetIfChanged(ref newName, value); }
        public ushort ScoreVisual { get => scores[0]; set => this.RaiseAndSetIfChanged(ref scores[0], value); }
        public ushort ScoreArchitecture { get => scores[1]; set => this.RaiseAndSetIfChanged(ref scores[1], value); }
        public ushort ScoreNetworks { get => scores[2]; set => this.RaiseAndSetIfChanged(ref scores[2], value); }

        public float ScoreVisualSr { get => sc_score[0]; set => this.RaiseAndSetIfChanged(ref sc_score[0], value); }
        public float ScoreArchitectureSr { get => sc_score[1]; set => this.RaiseAndSetIfChanged(ref sc_score[1], value); }
        public float ScoreNetworksSr { get => sc_score[2]; set => this.RaiseAndSetIfChanged(ref sc_score[2], value); }
        public float ScoreAverageSr { get => sc_score[3]; set => this.RaiseAndSetIfChanged(ref sc_score[3], value); }

        public SolidColorBrush ColorVisualSr { get => colorBrush[0]; set => this.RaiseAndSetIfChanged(ref colorBrush[0], value); }
        public SolidColorBrush ColorArchitectureSr { get => colorBrush[1]; set => this.RaiseAndSetIfChanged(ref colorBrush[1], value); }
        public SolidColorBrush ColorNetworksSr { get => colorBrush[2]; set => this.RaiseAndSetIfChanged(ref colorBrush[2], value); }
        public SolidColorBrush ColorAverageSr { get => colorBrush[3]; set => this.RaiseAndSetIfChanged(ref colorBrush[3], value); }

        
    }
}
