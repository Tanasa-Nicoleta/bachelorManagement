using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Entities;
using BachelorManagement.DataLayer.Enums;
using BachelorManagement.Interfaces;
using System.Linq;

namespace BachelorManagement.BusinessLayer.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IRepository<Consultation> _consultationRepository;

        public ConsultationService(IRepository<Consultation> consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public void AddConsultation(int teacherId, WeekDays weekDay, string interval)
        {
            _consultationRepository.Add(
                    new Consultation
                    {
                        TeacherId = teacherId,
                        Day = weekDay,
                        Interval = interval
                    }
                );
        }

        public Consultation GetTeacherConsultation(int teacherId)
        {
            return _consultationRepository.GetAll().FirstOrDefault(c => c.TeacherId == teacherId);
        }

        public void RemoveConsultation(Consultation consultation)
        {
            _consultationRepository.Delete(consultation);
        }

        public void UpdateConsultation(Consultation consultation)
        {
            Consultation oldConsultation = new Consultation();

            if (consultation != null)
                oldConsultation = _consultationRepository.GetAll().FirstOrDefault(c => c.Id == consultation.Id);

            if (oldConsultation != null)
            {
                if (oldConsultation.Interval != null)
                    oldConsultation.Interval = consultation.Interval;

                if (oldConsultation.Day != consultation.Day)
                    oldConsultation.Day = consultation.Day;

                _consultationRepository.Update(oldConsultation);
            }
        }
    }
}
