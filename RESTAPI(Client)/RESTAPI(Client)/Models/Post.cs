﻿namespace RESTAPI_Client_.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
