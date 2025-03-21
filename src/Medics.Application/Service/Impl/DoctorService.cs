using AutoMapper;
using Medics.Application.DtoModels;
using Medics.Application.DtoModels.Doctor;
using Medics.Core.Entities;
using Medics.DataAccess.Repositories;

namespace Medics.Application.Service.Impl;

public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<List<DoctorResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var doctors = await _doctorRepository.GetAllAsync();
        return _mapper.Map<List<DoctorResponseDTO>>(doctors);
    }

    public async Task<DoctorResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        if (doctor == null) throw new Exception("Doctor not found.");

        return _mapper.Map<DoctorResponseDTO>(doctor);
    }

    public async Task<CreateDoctorResponseDTO> CreateAsync(DoctorCreateDTO createDoctorModel, CancellationToken cancellationToken = default)
    {
        var doctor = _mapper.Map<Doctor>(createDoctorModel);
        await _doctorRepository.AddAsync(doctor);

        return new CreateDoctorResponseDTO { Id = doctor.Id };
    }

    public async Task<UpdateDoctorResponseDTO> UpdateAsync(Guid id, DoctorUpdateDTO updateDoctorModel, CancellationToken cancellationToken = default)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        if (doctor == null) throw new Exception("Doctor not found.");

        _mapper.Map(updateDoctorModel, doctor);
        await _doctorRepository.UpdateAsync(doctor);

        return new UpdateDoctorResponseDTO { Id = doctor.Id };
    }

    public async Task<BaseResponseDTO> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        if (doctor == null)
        {
            return new BaseResponseDTO { Id = id, Success = false, Message = "Doctor not found" };
        }

        await _doctorRepository.DeleteAsync(doctor);

        return new BaseResponseDTO { Id = id, Success = true, Message = "Doctor deleted successfully" };
    }
}
