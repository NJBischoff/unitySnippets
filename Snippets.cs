 
    //GENERATES THE CORRECT PATH IN EACH ENVIRONMENT
    //These values below should math your Unity game setup defaults
    private string coName = "xyz_corp";
    private string gameName = "xyz";
    private string dataFolder = "xyz_data";

    public string LoadPath(string filename)
    {
        string path = "";

        bool errorOccured = true;

        if (UnityEngine.Application.platform == RuntimePlatform.WindowsPlayer || UnityEngine.Application.platform == RuntimePlatform.WindowsEditor)
        {
            errorOccured = false;
            path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + "\\" + coName + "\\" + gameName + "\\" + filename;
        }
        if (UnityEngine.Application.platform == RuntimePlatform.OSXEditor || UnityEngine.Application.platform == RuntimePlatform.OSXPlayer)
        {
            errorOccured = false;
            path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = path + "/Library/Application Support/" + coName + "/" + gameName + "/" + filename;
        }
        if (UnityEngine.Application.platform == RuntimePlatform.LinuxPlayer || UnityEngine.Application.platform == RuntimePlatform.LinuxPlayer)
        {
            errorOccured = false;
            path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = path + "/.config/unity3d/" + coName + "/" + gameName + "/" + filename;
        }
        if (errorOccured == true)
        {
            Debug.LogError("<color=red>[ERROR]</color>" + " " + "Could not Find Location of: " + filename + " @ " + UnityEngine.Application.platform + " - " + coName + " - " + gameName);
        }

        return path;
    }


    //CHECKS TO SEE IF THE DIRECTORY HAS BEEN CREATED IN THE USER FOLDER
    public bool checkIfDirectoryCreated()
    {
        bool hasBeenCreated = false;

        if (!Directory.Exists(loadPath("")))
        {
            Directory.CreateDirectory(loadPath(""));
            Debug.Log("<color=green>[SUCCESS]</color>" + " " + "Created Directory @ " + loadPath(""));
            hasBeenCreated = true;
        }
        else
        {
            hasBeenCreated = false;
        }
        if (Directory.Exists(loadPath("")))
        {
            hasBeenCreated = true;
        }

        return hasBeenCreated;
    }

    //Returns the Date, with an optional reformatting
    public string date(bool prettyFormat) //Monday, May 25, 2017, 2:45 PM
    {
        DateTime ThisDate = DateTime.Now;

        monthsArray.Add("Jan");
        monthsArray.Add("Feb");
        monthsArray.Add("Mar");
        monthsArray.Add("Apr");
        monthsArray.Add("May");
        monthsArray.Add("Jun");
        monthsArray.Add("Jul");
        monthsArray.Add("Aug");
        monthsArray.Add("Sep");
        monthsArray.Add("Oct");
        monthsArray.Add("Nov");
        monthsArray.Add("Dec");

        daysArray.Add("Sun");
        daysArray.Add("Mon");
        daysArray.Add("Tue");
        daysArray.Add("Wed");
        daysArray.Add("Thu");
        daysArray.Add("Fri");
        daysArray.Add("Sat");

        int dayOfTheWeek = (int)ThisDate.DayOfWeek;
        int dayDate = ThisDate.Day;
        int month = ThisDate.Month;
        int year = ThisDate.Year;
        int hour = ThisDate.Hour;
        int minute = ThisDate.Minute;
        int second = ThisDate.Second;
        string currentDate = null;
        string tempMinute = "";

        string ampm = ThisDate.ToString("tt", CultureInfo.InvariantCulture);

        if (minute <= 9) tempMinute = "0";

        if (prettyFormat == true)
        {
            currentDate = daysArray[dayOfTheWeek] + ", " + monthsArray[month - 1] + " " + dayDate.ToString() + ", " + year.ToString() + ", " + hour.ToString() + ":" + tempMinute + minute.ToString() + " " + ampm;
        }
        else
        {
            currentDate = "" + (month).ToString() + "" + dayDate.ToString() + "" + year.ToString() + "" + hour.ToString() + "" + tempMinute + minute.ToString();
        }

        return currentDate;
    }


    //Rounds a Number
    public float Round(float input)
    {
        return 1 * Mathf.Round((input / 1));
    }

    //Returns the Bounds of on object as a Vector3
    public Vector3 getCenterBounds(GameObject thisObject)
    {
        Bounds thisBounds = thisObject.GetComponent<Collider>().bounds;
        return thisBounds.center;
    }

    //Returns the MinBounds by GameObject
    public Vector3 getMinBounds(GameObject thisObject)
    {
        Bounds thisBounds = thisObject.GetComponent<Collider>().bounds;
        return thisBounds.min;
    }

    //Returns the center of an array of Vectors
    public Vector3 CenterOfVectors(Vector3[] vectors)
    {
        Vector3 sum = Vector3.zero;

        if (vectors == null || vectors.Length == 0)
        {
            return sum;
        }

        foreach (Vector3 vec in vectors)
        {
            sum += vec;
        }
        return sum / vectors.Length;
    }

    //Returns a float when a string is inputted and fails gracefully
    float FloatParse(string value)
    {
        float result = 0f;

        try
        {
            result = float.Parse(value);
        }
        catch (System.FormatException e)
        {
            Debug.LogWarning(this.name + " HAS MALFORMED DATA: " + value);
            result = 0f;
        }

        return result;
    }

    //Returns a int when a string is inputted and fails gracefully
    int IntParse(string value)
    {
        int result = 0;

        try
        {
            result = int.Parse(value);
        }
        catch (System.FormatException e)
        {
            Debug.LogWarning(this.name + " HAS MALFORMED DATA: " + value);
            result = 0;
        }

        return result;
    }

