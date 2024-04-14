using System;
using System.Runtime.Serialization;

[Serializable]
public class BestScore
{
    [DataMember]
    public string Name;

    [DataMember]
    public int Score;

    public BestScore(string name, int score)
    {
        this.Name = name;
        this.Score = score;
    }
}
