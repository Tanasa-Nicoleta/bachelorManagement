using BachelorManagement.DataLayer.Entities;
using BachelorManagement.DataLayer.Enums;

namespace BachelorManagement.Interfaces
{
    public interface IConsultationService
    {
        void AddConsultation(int teacherId, WeekDays weekDay, string interval);
        void RemoveConsultation(Consultation consultation);
        void UpdateConsultation(Consultation consultation);
        Consultation GetTeacherConsultation(int teacherId);
    }
}
