using System;

namespace BachelorManagement.DataLayer.Entities
{
    public class MeetingRequest
    {
        public DateTime Date { get; set; }
        public int TeacherId;
        public int StudentId;
    }
}
