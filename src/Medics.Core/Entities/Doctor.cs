﻿using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class Doctor : BaseEntity
{
    public DoctorCategory DoctorCategory { get; set; }
    public Guid DoctorCategoryId { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<AppointmentPayment> Appointments { get; set; }
    public ICollection<Chat> Chats { get; set; }
}
