using System.Collections.Generic;

[System.Serializable]
public class StageInfo
{
    public int clearLevel = -1;
    public List<float> bestClearTimeList = new List<float>();
    public List<int> gemCountList = new List<int>();
    public List<int> starCountList = new List<int>();
}
