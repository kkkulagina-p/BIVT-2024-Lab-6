﻿using System;
using System.Linq;
namespace Lab_6
{
    public class White_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _scores;
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            public double[] Scores
            {
                get
                {
                    if (_scores == null) return default(double[]);
                    var newArray = new double[_scores.Length];
                    Array.Copy(_scores, newArray, _scores.Length);
                    return newArray;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_scores != null) return _scores.Sum();
                    else return 0;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];
            }

            public void PlayMatch(double result)
            {
                if (_scores == null) return;
                double[] newScores = new double[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                bool y;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {TotalScore}");
            }
        }
    }
}