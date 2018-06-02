using BachelorManagement.DataLayer.Entities;
using BachelorManagement.DataLayer.Enums;
using System;
using System.Collections.Generic;

namespace BachelorManagement.Interfaces
{
    public interface IMeetingRequestService
    {
        void AddMeetingRequest(int studentId, int teacherId, DateTime Date);
        void DeleteMeetingRequest(int studentId, int teacherId);
        void UpdateMeetingRequestStatus(MeetingRequest meetingRequest, MeetingRequestStatus status);
        MeetingRequest GetStudentMeetingRequests(int studentId);
        List<MeetingRequest> GetTeacherMeetingRequests(int teacherID);
    }
}
