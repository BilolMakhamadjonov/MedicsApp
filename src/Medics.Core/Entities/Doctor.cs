﻿using Medics.Core.Comman;
using Medics.Core.Comman;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medics.Core.Entities;

public class Doctor : BaseEntity
{
    public DoctorCategory DoctorCategory { get; set; }
    public Guid DoctorCategoryId { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Chat> Chats { get; set; }
    public DoctorDetails DoctorDetails { get; set; }
    [NotMapped]
    public double Distance => 800;
}
