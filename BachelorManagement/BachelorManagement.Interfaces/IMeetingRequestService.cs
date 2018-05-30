using BachelorManagement.DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace BachelorManagement.Interfaces
{
    public interface IMeetingRequestService
    {
        void AddMeetingRequest(int studentId, int teacherId, DateTime Date);
        MeetingRequest GetStudentMeetingRequests(int studentId);
        List<MeetingRequest> GetTeacherMeetingRequests(int teacherID);
    }
}
