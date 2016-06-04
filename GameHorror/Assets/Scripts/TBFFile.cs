using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class TBFFile
{
    private string fileName;

    public TBFFile(string fileName)
    {
        this.fileName = fileName;
    }

    /// <summary>
    /// Loads data from the file
    /// </summary>
    /// <returns>Dictionary<string, Dictionary<string, object>></returns>
    public Dictionary<string, Dictionary<string, object>> LoadFile()
    {
        //Prepare a dictionary of dictionarys
        var allData = new Dictionary<string, Dictionary<string, object>>();
        
        //Opens the file and starts to read it
        using (var sr = new StreamReader(fileName))
        {
            //Prepare a dictionary to store ROOT values in (values withouth a section)
            var sectionData = new Dictionary<string, object>();
            string sectionName = "ROOT";

            //Read line until we are at the end of the file
            while (!sr.EndOfStream)
            {
                //Read line and remove excess whitespaces
                string line = sr.ReadLine().Trim();
                //If line is empty or starts with a # we ignore it
                if (line == "" || line.First() == '#')
                    continue;

                //If a line starts with ! it's a new section
                if (line.First() == '!')
                {
                    //Store the old section in our Dictionary of Dictionarys
                    allData[sectionName] = sectionData;

                    //Get the new section name, ignoring the !
                    sectionName = line.Substring(1);
                    //Creating the new Dictionary to represent the section
                    sectionData = new Dictionary<string, object>();
                }
                //If line does NOT start with ! it must be an entry, aka data, values
                else
                {
                    //Find the end of the entry name, aka the pivot of the entry
                    int pivot = line.IndexOf(' ');
                    //Get the entry name and trim of excess whitespaces
                    string name = line.Substring(0, pivot).Trim();
                    //Get the raw entry data and trim off the excess whitespaces
                    string rawData = line.Substring(pivot).Trim();
                    //Handle the rawdata
                    object data = handleEntry(rawData);
                    //Save the data to our section Dictionary using the entry name
                    sectionData[name] = data;
                }
            }
            //Store the last section in our Dictionary of Dictionarys
            allData[sectionName] = sectionData;
        }
        return allData;
    }
    /// <summary>
    /// Handles the raw data from our sections
    /// </summary>
    /// <param name="rawData"></param>
    /// <returns></returns>
    private object handleEntry(string rawData)
    {
        //Get the first character of our data, it represents the type of data
        //i: integer, f: float, s: string, b: boolean
        char type = rawData.First();

        //Our Delegate that delegates the parsing of data
        handleData handle;

        switch (type)
        {
            case 'i':
                handle = handleInt;         //Set our delegate to parse an integer
                break;
            case 'f':
                handle = handleFloat;       //Set our delegate to parse a Float
                break;
            case 's':
                handle = handleString;      //Set our delegate to parse a string
                break;
            case 'b':
                handle = handleBool;        //Set out delegate to parse a boolean
                break;
            default:
                throw new FormatException("File is corrupt");       //Shit went wrong
        }

        //Do the actual parsing decided in the switch-case using the rawData minus the typeidentifier
        return handle(rawData.Substring(1));
    }

    /// <summary>
    /// Saves data to file
    /// </summary>
    /// <param name="data"></param>
    public void SaveFile(Dictionary<string, Dictionary<string, object>> dataToSave)
    {
        //Opens the file for writing
        var sw = new StreamWriter(fileName, false);

        using (sw)
        {
            //For each Dictionary (section) in our Dictionary of Dictionarys - loop
            foreach (KeyValuePair<string, Dictionary<string, object>> section in dataToSave)
            {
                //Write ! followed by section name
                sw.WriteLine("!" + section.Key);

                //For each Property in our section
                foreach (KeyValuePair<string, object> data in section.Value)
                {
                    //Write the name of the property
                    sw.Write(data.Key + " ");
                    //Get the value of the property
                    object v = data.Value;
                    //Get the type of the property (int, float, string, bool)
                    Type t = v.GetType();

                    if (t == typeof(int))
                        sw.WriteLine("i" + v.ToString());                       //If int write i followed by the value
                    if (t == typeof(float))
                        sw.WriteLine("f" + v.ToString());                       //If flaot write f followed by the value - possible errorpoint due to localization.
                    if (t == typeof(bool))
                        sw.WriteLine("b" + v.ToString());                       //If bool write b followed by the value
                    if (t == typeof(string))
                        sw.WriteLine("s\"" + v.ToString() + "\"");              //If string write s followed by the value encapsuled in "
                }
            }
        }

        //All done, file is closed data is saved in a .tbf file (readable to humans)
    }

    private delegate object handleData(string s);

    private object handleInt(string s)
    {
        int value = 0;
        if (int.TryParse(s, out value))
            return value;
        throw new FormatException("File is corrupt");
    }

    private object handleFloat(string s)
    {
        float value = 0;
        //Parse a string as a float. InvariantCulture lets us always use . instead of , regardless of localization
        if (float.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out value))
            return value;
        throw new FormatException("File is corrupt");
    }

    private object handleBool(string s)
    {
        bool value = false;
        if (bool.TryParse(s, out value))
            return value;
        throw new FormatException("File is corrupt");
    }

    private object handleString(string s)
    {
        //Ignores the " at the begining of a string and at the end of a string
        return s.Substring(1, s.Length - 2);
    }
}