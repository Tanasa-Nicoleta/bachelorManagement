using System;
using BachelorManagement.Interfaces;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Enums;
using System.Linq;
using System.Collections.Generic;

namespace BachelorManagement.BusinessLayer.Services
{
    public class MeetingRequestService : IMeetingRequestService
    {
        private IRepository<MeetingRequest> _meetingRequestRepository { get; set; }

        public MeetingRequestService(IRepository<MeetingRequest> meetingRequestRepository)
        {
            _meetingRequestRepository = meetingRequestRepository;
        }

        public void AddMeetingRequest(int studentId, int teacherId, DateTime date)
        {
            _meetingRequestRepository.Add(
                new MeetingRequest
                {
                    StudentId = studentId,
                    TeacherId = teacherId,
                    Date = date,
                    Status = MeetingRequestStatus.Pending
                }
            );
        }

        public MeetingRequest GetStudentMeetingRequests(int studentId)
        {
             return _meetingRequestRepository.GetAll().FirstOrDefault(m => m.StudentId == studentId);
        }

        public List<MeetingRequest> GetTeacherMeetingRequests(int teacherId)
        {
            return _meetingRequestRepository.GetAll().Where(m => m.TeacherId == teacherId).ToList();
        }

        public void DeleteMeetingRequest(int studentId, int teacherId)
        {
            var meetingRequest = _meetingRequestRepository.GetAll().FirstOrDefault(m => m.StudentId == studentId && m.TeacherId == teacherId);

            _meetingRequestRepository.Delete(meetingRequest);
        }

        public void UpdateMeetingRequestStatus(MeetingRequest meetingRequest, MeetingRequestStatus status)
        {
            var oldMeetingrequest = _meetingRequestRepository.GetAll().FirstOrDefault(m => m.Id == meetingRequest.Id);
            oldMeetingrequest.Status = status;

            _meetingRequestRepository.Update(oldMeetingrequest);
        }
    }
}
