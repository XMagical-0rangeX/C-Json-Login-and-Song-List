// SAVE AND LOAD TO JSON DEMO by MR. V Adapted by Atlantis
//*********************************************************************************
#nullable disable

// Import JSON module
using System.Text.Json;

// Read data from file as a json string
string jsonString = File.ReadAllText("point-data.json");

// The Deserialize method will convert a json string to data
List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);
List<Song> songs = new List<Song>();

bool egg = true;
bool egg2 = true;
string cheese = "";
while (egg2)
{
    while (egg)
    {
        Console.WriteLine("");
        Console.WriteLine("DATA");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. New User");
        Console.WriteLine("3. Exit");
        Console.WriteLine("");
        int nval = TParse();
        if (nval == 1)
        {
            cheese = Login(users);
            if (cheese != "")
            {
                egg = false;
            }
        }
        else if (nval == 2)
        {
            users = NewUse(users);
        }
        else if (nval == 3)
        {
            egg2 = false;
            break;
        }
    }
    if (egg2 == false)
    {
        break;
    }
    Console.WriteLine("");
    Console.WriteLine("Welcome " + cheese);
    Console.WriteLine("1. Favorites List");
    Console.WriteLine("2. Change Password/Username");
    Console.WriteLine("3. Logout");
    Console.WriteLine("");
    int nnval = TParse();
    if (nnval == 1)
    {
        Favlist(users, songs, cheese);
    }
    else if (nnval == 2)
    {
        cheese = ChangeUp(users, cheese);
    }
    else if (nnval == 3)
    {
        egg = true;
    }
}
// Verify Contents of points
foreach (User user in users)
{
    Console.WriteLine(user);
}
// Use the JSON Serialize method to convert point data to a json string
jsonString = JsonSerializer.Serialize(users);

// Write the jsonString to a file
File.WriteAllText("point-data.json", jsonString);

static int TParse()
{
    string maf = Console.ReadLine();
    int nemaf;
    int.TryParse(maf, out nemaf);
    return nemaf;
}
static string Login(List<User> users)
{
    Console.WriteLine("Username?");
    string uselog = Console.ReadLine();
    foreach (User user in users)
    {
        if (uselog == user.Username)
        {
            Console.WriteLine("Password?");
            string passlog = Console.ReadLine();
            if (passlog == user.Password)
            {
                Console.WriteLine("Success! Welcome " + uselog + "!");
                return uselog;
            }
            else
            {
                Console.WriteLine("Wrong Password");
                return "";
            }
        }
    }
    Console.WriteLine("Username Not Found");
    return "";
}
static List<User> NewUse(List<User> users)
{
    bool egg = true;
    string name = "";
    while (egg)
    {
        Console.WriteLine("Name?");
        name = Console.ReadLine();
        egg = false;
        if (name == "")
        {
            egg = true;
            Console.WriteLine("Username Invalid");
        }
        else
        {
            foreach (User user in users)
            {
                if (user.Username == name)
                {
                    egg = true;
                    Console.WriteLine("Username Taken");
                }
            }
        }

    }
    Console.WriteLine("Password?");
    string pass = Console.ReadLine();
    users.Add(new User(name, pass));
    Console.WriteLine("Confirmed");
    return users;
}
static string ChangeUp(List<User> users, string name)
{
    bool egg = true;
    while (egg)
    {
        Console.WriteLine("");
        Console.WriteLine("CHANGE");
        Console.WriteLine("1. Username");
        Console.WriteLine("2. Password");
        Console.WriteLine("3. Exit");
        Console.WriteLine("");
        int hval = TParse();
        if (hval == 1)
        {
            Console.WriteLine("New Username?");
            string pass = Console.ReadLine();
            foreach (User user in users)
            {
                if (user.Username == name)
                {
                    name = pass;
                    user.Username = pass;
                }
            }
            Console.WriteLine("Successfully Updated Username");
        }
        else if (hval == 2)
        {
            Console.WriteLine("New Password?");
            string pass = Console.ReadLine();
            foreach (User user in users)
            {
                if (user.Username == name)
                {
                    user.Password = pass;
                }
            }
            Console.WriteLine("Successfully Updated Password");
        }
        else if (hval == 3)
        {
            break;
        }
    }

    return name;
}
static void Favlist(List<User> users, List<Song> songs, string nm)
{
    bool egg = true;
    while (egg)
    {
        Console.WriteLine("");
        Console.WriteLine("List");
        foreach (User user in users)
        {
            for (int i = 0; i < user.Faves.Count; i++)
            {
                Console.WriteLine(user.Faves[i].Title + " | " + user.Faves[i].Artist + " | " + user.Faves[i].Genre);
            }
        }
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Remove");
        Console.WriteLine("3. Exit");
        Console.WriteLine("");
        int nnval = TParse();
        if (nnval == 1)
        {
            Console.WriteLine("Name?");
            string name = Console.ReadLine();
            Console.WriteLine("Artist?");
            string name2 = Console.ReadLine();
            Console.WriteLine("Genre?");
            string name3 = Console.ReadLine();
            foreach (User user in users)
            {
                if (user.Username == nm)
                {
                    user.Faves.Add(new Song(name, name2, name3));
                }
            }
        }
        else if (nnval == 2)
        {
            Console.WriteLine("Name?");
            string name = Console.ReadLine();
            Console.WriteLine("Artist?");
            string name2 = Console.ReadLine();
            bool egad = false;
            foreach (User user in users)
            {
                if (user.Username == nm)
                {
                    for (int i = 0; i < user.Faves.Count; i++)
                    {
                        if (name == user.Faves[i].Title && name2 == user.Faves[i].Artist)
                        {
                            user.Faves.RemoveAt(i);
                            Console.WriteLine("Song Sucessfully Removed!");
                            egad = true;
                            break;
                        }
                    }
                }
            }
            if (egad)
            {
                Console.WriteLine("Couldn't Locate Song...");
            }
        }
        else if (nnval == 3)
        {
            break;
        }
    }

}
class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Song> Faves { get; set; }

    public User(string username, string password)
    {
        this.Username = username;
        this.Password = password;
        this.Faves = new List<Song>();
    }
}
class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }

    public Song(string title, string artist, string genre)
    {
        this.Title = title;
        this.Artist = artist;
        this.Genre = genre;
    }
}
