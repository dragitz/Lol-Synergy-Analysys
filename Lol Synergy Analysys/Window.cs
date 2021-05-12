using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Lol_Synergy_Analysys
{
    public partial class Title : Form
    {
        public Title()
        {
            InitializeComponent();
        }


        /* 
        TODO:


                Data grabbing


        Get last version of dragon https://ddragon.leagueoflegends.com/api/versions.json (usually on top)                       DONE

        Use version number here https://ddragon.leagueoflegends.com/cdn/6.24.1/data/en_US/champion.json                         DONE

        For then store each champion name and the corresponding key                                                             DONE

        Key will then be used to determine stuff in the .json provided by the blitz api:
        https://beta.iesdev.com/api/lolstats/champions?patch=11.6&region=world&tier=PLATINUM_PLUS&queue=420

        NOTE: The link above will have to be edited, only one digit may be inserted after a dot. (eg: 11.8 and not 11.8.1)
              I can let the user manually input the version or automatically do it.
                BOTH have pros and cons.
                I'll see whats best


                Calculations


        Now that we got our data, we can calculate our stuff based on the filters




        */
        public static class Globals
        {
            //public static Int32 BUFFER_SIZE = 512;

            public static String DRAGON_VERSION = "";                 //Last version of dragon

            public static String API_VERSION = "";                    //Shortened version of dargon (eg: 10.10.1 --> 10.10)



            public static String CHAMPIONS_ARRAY = "";                //Here we store all champions id with their corresponding name, will be used
                                                                      //to properly populate combo boxes

            public static String Name = "";                           // Used to know the selected champion name
            public static String ROLE = "";                           // Used to know the selected role
            public static String ID = "";                             // Used to know the selected champion id

            public static string[] ArrayRoles = { "ADC", "SUPPORT", "JUNGLE", "MID", "TOP" };

            public static String FINAL_OUTPUT = "";                   // Used to store and print team comp
            public static String FINAL_OUTPUT_CSV = "";               // Used to output data to a .csv format
            public static String FINAL_OUTPUT_CSV_TITLE = "";               // Used to output data to a .csv format




            public static String CHAMPIONS_ARRAY_ANALISYS = "";       // debug stuff








        }

        public class DummyClass
        {
            public int Value { get; set; }
            public string DisplayValue { get; set; }
        }


        private async void GetChampions_btn_Click(object sender, EventArgs e)
        {
            //Reset all comboboxes
            ADC_Box.Items.Clear();
            SUPPORT_Box.Items.Clear();
            JUNGLER_Box.Items.Clear();
            MID_Box.Items.Clear();
            TOP_Box.Items.Clear();

            //Reset role
            Globals.ROLE = "";

            //get last dragon version
            status1.Text = "Status: Getting API versions...";

            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ddragon.leagueoflegends.com/api/versions.json"))
                {
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:88.0) Gecko/20100101 Firefox/88.0");
                    request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                    request.Headers.TryAddWithoutValidation("Sec-GPC", "1");
                    request.Headers.TryAddWithoutValidation("Pragma", "no-cache");
                    request.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");

                    //Send request
                    var response = await httpClient.SendAsync(request);

                    //Store reply
                    string source = await response.Content.ReadAsStringAsync();
                    //Json stuff
                    dynamic parsedArray = JsonConvert.DeserializeObject(source);

                    //This takes the first item from the top = last version
                    Globals.DRAGON_VERSION = parsedArray[0];

                    //Output version (debug)
                    dragon_version.Text = "Dragon Version: " + Globals.DRAGON_VERSION;
                }

            }



            //Now we got the dragon version, we need to get the version value for the beta api

            string s = Globals.DRAGON_VERSION;
            string small = new string(s.Take(5).ToArray());
            if (small.EndsWith("."))
            {
                small = new string(s.Take(4).ToArray());
            }
            Globals.API_VERSION = small;
            api_version.Text = "API Version: " + Globals.API_VERSION;






            //Now we have to fill combobox with champion names linked to championids (key)
            //We can do this by using a get request to https://ddragon.leagueoflegends.com/cdn/XXX/data/en_US/champion.json
            //and replace XXX with the DRAGON_VERSION

            status1.Text = "Status: Getting champion ids...";

            handler = new HttpClientHandler();
            handler.UseCookies = false;
            // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
            handler.AutomaticDecompression = ~DecompressionMethods.None;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ddragon.leagueoflegends.com/cdn/" + Globals.DRAGON_VERSION + "/data/en_US/champion.json"))
                {

                    //Send request
                    var response = await httpClient.SendAsync(request);

                    //Store reply
                    string source = await response.Content.ReadAsStringAsync();

                    //This will store the json output as a string into the "JSON" variable
                    //You can print with:    Output.Text = source;
                    string JSON = source;

                    //Then to an array
                    dynamic parsedArray = JsonConvert.DeserializeObject(source);


                    //Create json string
                    string listA = "{\"data\":{";
                    //I think creating a new json array would be more efficient, so let's do that
                    foreach (dynamic item in parsedArray.data)
                    {

                        foreach (dynamic itemb in item)
                        {
                            //Create list
                            listA = listA + "\"" + itemb.key + "\"" + ":{\"championName\":" + "\"" + itemb.id + "\"," + "\"championId\":" + itemb.key + "},";

                        }

                    }


                    //Delete last ,    and close
                    listA = listA.Remove(listA.Length - 1);
                    listA = listA + "}}";

                    //Store the new output so it can later be used for our calculations
                    Globals.CHAMPIONS_ARRAY = listA;

                    //Output.Text = listA; //debug

                    //Then to an array
                    dynamic NewArray = JsonConvert.DeserializeObject(listA);

                    status1.Text = "Status: Populating comboboxes...";

                    //Populate all combo boxes
                    foreach (dynamic item in NewArray.data)
                    {
                        foreach (dynamic itemb in item)
                        {

                            ADC_Box.Items.Add(itemb.championName);
                            SUPPORT_Box.Items.Add(itemb.championName);
                            JUNGLER_Box.Items.Add(itemb.championName);
                            MID_Box.Items.Add(itemb.championName);
                            TOP_Box.Items.Add(itemb.championName);
                        }
                    }

                    ADC_Box.Text = "Unselected";
                    SUPPORT_Box.Text = "Unselected";
                    JUNGLER_Box.Text = "Unselected";
                    MID_Box.Text = "Unselected";
                    TOP_Box.Text = "Unselected";


                }
                status1.Text = "Status: Done!";
            }

            //Now we have populated all ComboBoxes.


            //What we need to do is detect user input (aka Champion name) and generate data (aka Teams)


            //To the calculate button !




        }











        private async void Calculate_btn_Click(object sender, EventArgs e)
        {
            decimal max_synergy = 0;
            if (Globals.ROLE != "")
            {

                var handler = new HttpClientHandler();

                /*

                1) Get json and store it https://beta.iesdev.com/api/lolstats/duo/roles/ADC/SUPPORT?language=en&patch=11.8&region=world&tier=PLATINUM_PLUS
                        NOTE: Edit the version and roles

                2) Get wanted role by checking if:
                            -Comboboxed are Unselected
                                or
                            -Preferred role stored in a variable
                                or
                            -Use the created array to check if the championName matches, if true get the championId and use it to compare to the linked list above



                */

                //Get the championID of our desired champion
                for (var i = 0; i < Globals.ArrayRoles.Length; i++)
                {
                    if (Globals.ArrayRoles[i] == Globals.ROLE)
                    {
                        //Then to an array
                        dynamic parsedArray = JsonConvert.DeserializeObject(Globals.CHAMPIONS_ARRAY);

                        //Find our needed data
                        foreach (dynamic item in parsedArray.data)
                        {

                            foreach (dynamic itemb in item)
                            {
                                if (itemb.championName == Globals.Name)
                                {
                                    Globals.ID = itemb.championId;
                                }
                            }
                        }
                    }
                }

                //Output.Text = "name:pw     "+Globals.Name+":"+Globals.ID;
                //var JSON_ARRAY = Globals.CHAMPIONS_ARRAY;

                Globals.FINAL_OUTPUT = Globals.ROLE + ": " + Globals.Name;
                Globals.FINAL_OUTPUT_CSV = Globals.Name;
                Globals.FINAL_OUTPUT_CSV_TITLE = Globals.ROLE;
                var score = 0;
                var the_id = "";
                decimal synergy = 0;

                //Start a loop. Yay code optimization!
                for (var i = 0; i < Globals.ArrayRoles.Length; i++)
                {
                    //Make sure to ignore our selected role
                    if (Globals.ArrayRoles[i] != Globals.ROLE)
                    {
                        //beta.iesdev.com/api/lolstats/duo/roles/ADC/SUPPORT?language=en&patch=11.8&region=world&tier=PLATINUM_PLUS

                        handler = new HttpClientHandler();
                        handler.UseCookies = false;
                        // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
                        handler.AutomaticDecompression = ~DecompressionMethods.None;
                        using (var httpClient = new HttpClient(handler))
                        {

                            //GET ADC + SUPPORT COMBO
                            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://beta.iesdev.com/api/lolstats/duo/roles/" + Globals.ROLE + "/" + Globals.ArrayRoles[i].ToString() + "?language=en&patch=" + Globals.API_VERSION + "&region=world&tier=PLATINUM_PLUS"))
                            {
                                //Send request
                                var response = await httpClient.SendAsync(request);

                                //Store reply
                                string source = await response.Content.ReadAsStringAsync();

                                //This will store the json output as a string into the "JSON" variable
                                //You can print with:    Output.Text = source;
                                string JSON = source;
                                //Output.Text = source; //debug
                                //Then to an array
                                dynamic parsedArray = JsonConvert.DeserializeObject(source);

                                //Store single structure of "data" inside "structure".. Yeah I'm very creative.
                                foreach (dynamic structure in parsedArray.data)
                                {

                                    //debug.Text = structure.ToString();
                                    //debug.Text = structure.champion.ToString();
                                    //debug.Text = structure.champion.champion_id + "   " + structure.champion.role;
                                    //string screen = new string(structure.duo_win_rate.ToString().Take(4).ToArray());
                                    //decimal duo_win_rate = Decimal.Parse(screen);
                                    //decimal duo_win_rate = Convert.ToDecimal(structure.duo_win_rate);



                                    //if (structure.champion.champion_id == Globals.ID && structure.champion.role == Globals.ROLE && structure.duo_win_rate > score && structure.duo_game_count >= MinDuoMatches.Value && MinDuoWinRate.Value >= duo_win_rate)
                                    if (structure.champion.champion_id == Globals.ID && structure.champion.role == Globals.ROLE && structure.duo_win_rate > score && score < 1)
                                    {
                                        //
                                        debug.Text = structure.duo_win_rate; //debug win%
                                        dynamic NewParsedArray = JsonConvert.DeserializeObject(Globals.CHAMPIONS_ARRAY);

                                        //Store single structure of "data" inside "structure".. Yeah I'm very creative.
                                        //We will use this to replace all champion ids to champion names
                                        foreach (dynamic ToChampName_Struct in NewParsedArray.data)
                                        {
                                            foreach (dynamic Ending in ToChampName_Struct)
                                            {

                                                if (Ending.championId == structure.duo_champion.champion_id)
                                                {
                                                    the_id = Ending.championName;
                                                }
                                            }

                                        }
                                        score = structure.duo_win_rate;
                                        synergy = synergy + Decimal.Parse(structure.duo_win_rate.ToString());
                                        Globals.FINAL_OUTPUT = Globals.FINAL_OUTPUT + "   " + Globals.ArrayRoles[i].ToString() + ": " + the_id;

                                    }

                                    //Here we send our data to final and reset variables (dunno if the last part is needed though, but I want to be sure)


                                }
                                score = 0;

                            }
                        }
                    }
                }

                synergy = synergy / 4;

                //Limiting to 0.6 prevents false positives

                max_synergy = synergy;
                //We generated our first team!

                //Now we need to convert all ids to champion names!

                //debug.Text = Globals.CHAMPIONS_ARRAY;


                synergy_label.Text = "Avg.synergy score: " + synergy.ToString();

                Output.Text = "";
                Output.AppendText("The following team has been generated to favor " + Globals.Name + " the most." + System.Environment.NewLine + System.Environment.NewLine);
                Output.AppendText(Globals.FINAL_OUTPUT + System.Environment.NewLine);
                Output.AppendText("Avg. synergy score: " + synergy.ToString() + System.Environment.NewLine);



            }

        }








        private async void button1_Click(object sender, EventArgs e)
        {
            decimal max_synergy = 0;
            for (var k = 0; k < JUNGLER_Box.Items.Count; k++)
            {
                if (Globals.ROLE == "ADC") { ADC_Box.SelectedIndex = k; }
                if (Globals.ROLE == "SUPPORT") { SUPPORT_Box.SelectedIndex = k; }
                if (Globals.ROLE == "MID") { MID_Box.SelectedIndex = k; }
                if (Globals.ROLE == "TOP") { TOP_Box.SelectedIndex = k; }
                if (Globals.ROLE == "JUNGLE") { JUNGLER_Box.SelectedIndex = k; }

                label1.Text = k + "/" + JUNGLER_Box.Items.Count;

                if (Globals.ROLE != "")
                {

                    var handler = new HttpClientHandler();

                    /*

                    1) Get json and store it https://beta.iesdev.com/api/lolstats/duo/roles/ADC/SUPPORT?language=en&patch=11.8&region=world&tier=PLATINUM_PLUS
                            NOTE: Edit the version and roles

                    2) Get wanted role by checking if:
                                -Comboboxed are Unselected
                                    or
                                -Preferred role stored in a variable
                                    or
                                -Use the created array to check if the championName matches, if true get the championId and use it to compare to the linked list above



                    */

                    //Get the championID of our desired champion
                    for (var i = 0; i < Globals.ArrayRoles.Length; i++)
                    {
                        if (Globals.ArrayRoles[i] == Globals.ROLE)
                        {
                            //Then to an array
                            dynamic parsedArray = JsonConvert.DeserializeObject(Globals.CHAMPIONS_ARRAY);

                            //Find our needed data
                            foreach (dynamic item in parsedArray.data)
                            {

                                foreach (dynamic itemb in item)
                                {
                                    if (itemb.championName == Globals.Name)
                                    {
                                        Globals.ID = itemb.championId;
                                    }
                                }
                            }
                        }
                    }

                    //Output.Text = "name:pw     "+Globals.Name+":"+Globals.ID;
                    //var JSON_ARRAY = Globals.CHAMPIONS_ARRAY;

                    Globals.FINAL_OUTPUT = Globals.ROLE + ": " + Globals.Name;
                    Globals.FINAL_OUTPUT_CSV = Globals.Name;
                    Globals.FINAL_OUTPUT_CSV_TITLE = Globals.ROLE;
                    var score = 0;
                    var the_id = "";
                    decimal synergy = 0;

                    //Start a loop. Yay code optimization!
                    for (var i = 0; i < Globals.ArrayRoles.Length; i++)
                    {
                        //Make sure to ignore our selected role
                        if (Globals.ArrayRoles[i] != Globals.ROLE)
                        {
                            //beta.iesdev.com/api/lolstats/duo/roles/ADC/SUPPORT?language=en&patch=11.8&region=world&tier=PLATINUM_PLUS

                            handler = new HttpClientHandler();
                            handler.UseCookies = false;
                            // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
                            handler.AutomaticDecompression = ~DecompressionMethods.None;
                            using (var httpClient = new HttpClient(handler))
                            {

                                //GET ADC + SUPPORT COMBO
                                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://beta.iesdev.com/api/lolstats/duo/roles/" + Globals.ROLE + "/" + Globals.ArrayRoles[i].ToString() + "?language=en&patch=" + Globals.API_VERSION + "&region=world&tier=PLATINUM_PLUS"))
                                {
                                    //Send request
                                    var response = await httpClient.SendAsync(request);

                                    //Store reply
                                    string source = await response.Content.ReadAsStringAsync();

                                    //This will store the json output as a string into the "JSON" variable
                                    //You can print with:    Output.Text = source;
                                    string JSON = source;
                                    debug.Text = source; //debug
                                    //Then to an array
                                    dynamic parsedArray = JsonConvert.DeserializeObject(source);

                                    //Store single structure of "data" inside "structure".. Yeah I'm very creative.
                                    foreach (dynamic structure in parsedArray.data)
                                    {

                                        //debug.Text = structure.ToString();
                                        //debug.Text = structure.champion.ToString();
                                        //debug.Text = structure.champion.champion_id + "   " + structure.champion.role;
                                        //string screen = new string(structure.duo_win_rate.ToString().Take(4).ToArray());
                                        //decimal duo_win_rate = Decimal.Parse(screen);
                                        //decimal duo_win_rate = Convert.ToDecimal(structure.duo_win_rate);



                                        //if (structure.champion.champion_id == Globals.ID && structure.champion.role == Globals.ROLE && structure.duo_win_rate > score && structure.duo_game_count >= MinDuoMatches.Value && MinDuoWinRate.Value >= duo_win_rate)
                                        if (structure.champion.champion_id == Globals.ID && structure.champion.role == Globals.ROLE && structure.duo_win_rate > score && score < 1)
                                        {
                                            //
                                            //debug.Text = structure.duo_win_rate; //debug win%
                                            dynamic NewParsedArray = JsonConvert.DeserializeObject(Globals.CHAMPIONS_ARRAY);

                                            //Store single structure of "data" inside "structure".. Yeah I'm very creative.
                                            //We will use this to replace all champion ids to champion names
                                            foreach (dynamic ToChampName_Struct in NewParsedArray.data)
                                            {
                                                foreach (dynamic Ending in ToChampName_Struct)
                                                {

                                                    if (Ending.championId == structure.duo_champion.champion_id)
                                                    {
                                                        the_id = Ending.championName;
                                                    }
                                                }

                                            }
                                            score = structure.duo_win_rate;
                                            synergy = synergy + Decimal.Parse(structure.duo_win_rate.ToString());
                                            Globals.FINAL_OUTPUT = Globals.FINAL_OUTPUT + "   " + Globals.ArrayRoles[i].ToString() + ": " + the_id;

                                            //CSV Collction
                                            if (!Globals.FINAL_OUTPUT_CSV_TITLE.Contains(Globals.ArrayRoles[i].ToString()))
                                            {
                                                Globals.FINAL_OUTPUT_CSV_TITLE = Globals.FINAL_OUTPUT_CSV_TITLE + ";" + Globals.ArrayRoles[i].ToString();
                                            }
                                            Globals.FINAL_OUTPUT_CSV = Globals.FINAL_OUTPUT_CSV + ";" + the_id;


                                        }

                                        //Here we send our data to final and reset variables (dunno if the last part is needed though, but I want to be sure)


                                    }
                                    score = 0;

                                }
                            }
                        }
                    }


                    synergy = synergy / 4;

                    //Limiting to 0.6 prevents false positives
                    if (synergy > max_synergy && synergy < Convert.ToDecimal(0.70))
                    {
                        max_synergy = synergy;
                        //We generated our first team!

                        //Now we need to convert all ids to champion names!

                        //debug.Text = Globals.CHAMPIONS_ARRAY;


                        synergy_label.Text = "Avg.synergy score: " + synergy.ToString();

                        Output.Text = "";
                        Output.AppendText("The following team has been generated to favor " + Globals.Name + " the most." + System.Environment.NewLine + System.Environment.NewLine);
                        Output.AppendText(Globals.FINAL_OUTPUT + System.Environment.NewLine);
                        Output.AppendText("Avg. synergy score: " + synergy.ToString() + System.Environment.NewLine);



                        /*
                        if (!debug.Text.Contains(Globals.FINAL_OUTPUT_CSV_TITLE))
                        { debug.AppendText(Globals.FINAL_OUTPUT_CSV_TITLE + ";Synergy" + System.Environment.NewLine); }

                        debug.AppendText(Globals.FINAL_OUTPUT_CSV + ";" + max_synergy + System.Environment.NewLine);
                        Globals.FINAL_OUTPUT_CSV = "";
                        */


                    }


                }

                //Print .csv here

            }

            //For terminated
            label1.Text = JUNGLER_Box.Items.Count + "/" + JUNGLER_Box.Items.Count;


        }




        private void ADC_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.ROLE = "ADC";

            SUPPORT_Box.Text = "Unselected";
            JUNGLER_Box.Text = "Unselected";
            MID_Box.Text = "Unselected";
            TOP_Box.Text = "Unselected";

            Globals.Name = ADC_Box.Text;
        }

        private void SUPPORT_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.ROLE = "SUPPORT";

            ADC_Box.Text = "Unselected";
            JUNGLER_Box.Text = "Unselected";
            MID_Box.Text = "Unselected";
            TOP_Box.Text = "Unselected";

            Globals.Name = SUPPORT_Box.Text;
        }

        private void JUNGLER_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.ROLE = "JUNGLE";

            ADC_Box.Text = "Unselected";
            SUPPORT_Box.Text = "Unselected";
            MID_Box.Text = "Unselected";
            TOP_Box.Text = "Unselected";

            Globals.Name = JUNGLER_Box.Text;
        }

        private void MID_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.ROLE = "MID";

            ADC_Box.Text = "Unselected";
            SUPPORT_Box.Text = "Unselected";
            JUNGLER_Box.Text = "Unselected";
            TOP_Box.Text = "Unselected";

            Globals.Name = MID_Box.Text;
        }

        private void TOP_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.ROLE = "TOP";

            ADC_Box.Text = "Unselected";
            SUPPORT_Box.Text = "Unselected";
            JUNGLER_Box.Text = "Unselected";
            MID_Box.Text = "Unselected";

            Globals.Name = TOP_Box.Text;
        }


    }
}
