using System.Linq;
using AspHomework.DAL.Entities;

namespace AspHomework.DAL
{
    public static class DatabaseSeeder
    {
        private const string LOREM_IPSUM =
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas fermentum, sem in pharetra pellentesque, velit turpis volutpat ante, in pharetra metus odio a lectus. Mauris dictum facilisis augue. Fusce suscipit libero eget elit. Maecenas aliquet accumsan leo. Nullam at arcu a est sollicitudin euismod. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Integer malesuada. Sed convallis magna eu sem. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Integer malesuada. Proin mattis lacinia justo. In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Nulla quis diam. Duis risus.Aliquam erat volutpat. Aenean vel massa quis mauris vehicula lacinia. Proin in tellus sit amet nibh dignissim sagittis. In convallis. Duis viverra diam non justo. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Sed ac dolor sit amet purus malesuada congue. Maecenas libero. Nullam sapien sem, ornare ac, nonummy non, lobortis a enim. Phasellus faucibus molestie nisl. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Duis risus. Cras pede libero, dapibus nec, pretium sit amet, tempor quis. Ut tempus purus at lorem. Donec iaculis gravida nulla. Aliquam erat volutpat.";

        public static void Initialize(ApplicationDbContext context)
        {            
            context.Database.EnsureCreated();

            if (context.Rooms.Any()) return;

            context.Rooms.Add(new Room()
                {Name = "UCL Chamber", OpenFrom = 8, OpenTo = 20, Description = LOREM_IPSUM.Substring(0, 300)});
            context.Rooms.Add(new Room()
            {
                Name = "Bungee Jumping VR", OpenFrom = 14, OpenTo = 20, Description = LOREM_IPSUM.Substring(0, 120)
            });
            context.Rooms.Add(new Room()
            {
                Name = "Lets go for Docker", OpenFrom = 13, OpenTo = 15, Description = LOREM_IPSUM.Substring(0, 30)
            });
            context.Rooms.Add(new Room()
                {Name = "OzoBots testing", OpenFrom = 5, OpenTo = 10, Description = LOREM_IPSUM.Substring(0, 240)});
            context.Rooms.Add(new Room()
                {Name = "Parukarka room", OpenFrom = 10, OpenTo = 18, Description = LOREM_IPSUM.Substring(0, 201)});
            context.Rooms.Add(new Room()
            {
                Name = "Classic 7 room n.56", OpenFrom = 3, OpenTo = 16, Description = LOREM_IPSUM.Substring(0, 199)
            });
            context.Rooms.Add(new Room()
                {Name = "Room 1.11", OpenFrom = 0, OpenTo = 24, Description = LOREM_IPSUM.Substring(0, 198)});
            context.SaveChanges();
        }
    }
}