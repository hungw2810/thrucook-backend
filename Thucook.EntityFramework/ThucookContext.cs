using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class ThucookContext : DbContext
    {
        public ThucookContext()
        {
        }

        public ThucookContext(DbContextOptions<ThucookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentStatusId> AppointmentStatusIds { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public virtual DbSet<DoctorSetting> DoctorSettings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormPropertyMapping> FormPropertyMappings { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationPatient> LocationPatients { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineUnitType> MedicineUnitTypes { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyValueType> PropertyValueTypes { get; set; }
        public virtual DbSet<ResultSheet> ResultSheets { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SignupCode> SignupCodes { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Symtom> Symtoms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=thru_cook;uid=root;password=Hung2001@;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.HasIndex(e => e.DoctorId, "doctor_id");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.HasIndex(e => e.LocationPatientId, "location_patient_id");

                entity.HasIndex(e => e.PatientId, "patient_id");

                entity.HasIndex(e => e.ScheduleId, "schedule_id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.ActualCheckInDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("actual_check_in_datetime");

                entity.Property(e => e.ActualFinishDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("actual_finish_datetime");

                entity.Property(e => e.ActualStartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("actual_start_datetime");

                entity.Property(e => e.AppointmentStatusId).HasColumnName("appointment_status_id");

                entity.Property(e => e.CancelReason)
                    .HasMaxLength(1024)
                    .HasColumnName("cancel_reason");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocationPatientId).HasColumnName("location_patient_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.StartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_datetime");

                entity.Property(e => e.Symtom)
                    .HasMaxLength(1024)
                    .HasColumnName("symtom");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_ibfk_4");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_ibfk_3");

                entity.HasOne(d => d.LocationPatient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.LocationPatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_ibfk_2");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("appointments_ibfk_1");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_ibfk_5");
            });

            modelBuilder.Entity<AppointmentStatusId>(entity =>
            {
                entity.HasKey(e => e.AppointmentStatusId1)
                    .HasName("PRIMARY");

                entity.ToTable("appointment_status_id");

                entity.Property(e => e.AppointmentStatusId1)
                    .ValueGeneratedNever()
                    .HasColumnName("appointment_status_id");

                entity.Property(e => e.AppointmentStatusName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("appointment_status_name");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctors");

                entity.HasIndex(e => e.SpecialityId, "speciality_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.DoctorCode)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("doctor_code");

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("doctor_name");

                entity.Property(e => e.DoctorSequence).HasColumnName("doctor_sequence");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("phone_number");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.YearOfExperience).HasColumnName("year_of_experience");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("doctors_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctors_ibfk_2");
            });

            modelBuilder.Entity<DoctorSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PRIMARY");

                entity.ToTable("doctor_schedules");

                entity.HasIndex(e => e.DoctorId, "doctor_id");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.EndDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.RecurrenceString)
                    .HasMaxLength(2048)
                    .HasColumnName("recurrence_string");

                entity.Property(e => e.ScheduleUntil)
                    .HasColumnType("datetime")
                    .HasColumnName("schedule_until");

                entity.Property(e => e.StartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSchedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_schedules_ibfk_2");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DoctorSchedules)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_schedules_ibfk_1");
            });

            modelBuilder.Entity<DoctorSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("doctor_setting");

                entity.HasIndex(e => e.DoctorId, "doctor_id");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.Property(e => e.BufferTimePerAppointmentInMinutes).HasColumnName("buffer_time_per_appointment_in_minutes");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.IsVisibleForBooking)
                    .HasColumnName("is_visible_for_booking")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.NumberOfAppointmentsPerSlot)
                    .HasColumnName("number_of_appointments_per_slot")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TimePerAppointmentInMinutes).HasColumnName("time_per_appointment_in_minutes");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_setting_ibfk_1");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_setting_ibfk_2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_3");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_ibfk_2");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("forms");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("form_name");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsEditable)
                    .HasColumnName("is_editable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("forms_ibfk_1");
            });

            modelBuilder.Entity<FormPropertyMapping>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.PropertyId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("form_property_mapping");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("location_name");

                entity.Property(e => e.MaxPrice).HasColumnName("max_price");

                entity.Property(e => e.MinPrice).HasColumnName("min_price");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");
            });

            modelBuilder.Entity<LocationPatient>(entity =>
            {
                entity.ToTable("location_patients");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.HasIndex(e => e.PatientId, "patient_id");

                entity.Property(e => e.LocationPatientId).HasColumnName("location_patient_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.Property(e => e.Allergy)
                    .HasMaxLength(1024)
                    .HasColumnName("allergy");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HeightInCm).HasColumnName("height_in_cm");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.LocationPatientCode)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("location_patient_code");

                entity.Property(e => e.LocationPatientSequence).HasColumnName("location_patient_sequence");

                entity.Property(e => e.MedicalHistory)
                    .HasMaxLength(1024)
                    .HasColumnName("medical_history");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.Property(e => e.WeightInKg).HasColumnName("weight_in_kg");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationPatients)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location_patients_ibfk_2");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LocationPatients)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("location_patients_ibfk_1");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("medicines");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.IsEditable)
                    .HasColumnName("is_editable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("medicines_ibfk_1");
            });

            modelBuilder.Entity<MedicineUnitType>(entity =>
            {
                entity.ToTable("medicine_unit_types");

                entity.Property(e => e.MedicineUnitTypeId).HasColumnName("medicine_unit_type_id");

                entity.Property(e => e.MedicineUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("medicine_unit_type_name");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patients");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.Property(e => e.Allergy)
                    .HasMaxLength(1024)
                    .HasColumnName("allergy");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HeightInCm).HasColumnName("height_in_cm");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MedicalHistory)
                    .HasMaxLength(1024)
                    .HasColumnName("medical_history");

                entity.Property(e => e.PatientCode)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("patient_code");

                entity.Property(e => e.PatientSequence).HasColumnName("patient_sequence");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WeightInKg).HasColumnName("weight_in_kg");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patients_ibfk_1");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("prescriptions");

                entity.HasIndex(e => e.AppointmentId, "appointment_id");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prescriptions_ibfk_1");
            });

            modelBuilder.Entity<PrescriptionMedicine>(entity =>
            {
                entity.ToTable("prescription_medicines");

                entity.HasIndex(e => e.MedicineId, "medicine_id");

                entity.HasIndex(e => e.MedicineUnitTypeId, "medicine_unit_type_id");

                entity.HasIndex(e => e.PrescriptionId, "prescription_id");

                entity.Property(e => e.PrescriptionMedicineId).HasColumnName("prescription_medicine_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Guide)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("guide");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("medicine_name");

                entity.Property(e => e.MedicineUnitTypeId).HasColumnName("medicine_unit_type_id");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prescription_medicines_ibfk_2");

                entity.HasOne(d => d.MedicineUnitType)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.MedicineUnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prescription_medicines_ibfk_3");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.PrescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prescription_medicines_ibfk_1");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("properties");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.HasIndex(e => e.PropertyValueTypeId, "property_value_type_id");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsEditable)
                    .HasColumnName("is_editable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.PropertyInternalName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("property_internal_name");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("property_name");

                entity.Property(e => e.PropertyValueTypeDetail)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("property_value_type_detail");

                entity.Property(e => e.PropertyValueTypeId).HasColumnName("property_value_type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("properties_ibfk_1");

                entity.HasOne(d => d.PropertyValueType)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyValueTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("properties_ibfk_2");
            });

            modelBuilder.Entity<PropertyValueType>(entity =>
            {
                entity.ToTable("property_value_type");

                entity.Property(e => e.PropertyValueTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("property_value_type_id");

                entity.Property(e => e.PropertyValueName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("property_value_name");
            });

            modelBuilder.Entity<ResultSheet>(entity =>
            {
                entity.ToTable("result_sheets");

                entity.HasIndex(e => e.AppointmentId, "appointment_id");

                entity.HasIndex(e => e.FormId, "form_id");

                entity.Property(e => e.ResultSheetId).HasColumnName("result_sheet_id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.ReExaminationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("re_examination_date");

                entity.Property(e => e.Result)
                    .HasColumnType("text")
                    .HasColumnName("result");

                entity.Property(e => e.Symtom)
                    .HasColumnType("text")
                    .HasColumnName("symtom");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.ResultSheets)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("result_sheets_ibfk_1");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.ResultSheets)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("result_sheets_ibfk_2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<SignupCode>(entity =>
            {
                entity.ToTable("signup_code");

                entity.Property(e => e.SignupCodeId).HasColumnName("signup_code_id");

                entity.Property(e => e.IsAvaiable)
                    .HasColumnName("is_avaiable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SignupCodeVale)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("signup_code_vale");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("specialities");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.SpecialityName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("speciality_name");

                entity.Property(e => e.SpecialtyShortName)
                    .HasMaxLength(128)
                    .HasColumnName("specialty_short_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Specialities)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("specialities_ibfk_1");
            });

            modelBuilder.Entity<Symtom>(entity =>
            {
                entity.ToTable("symtom");

                entity.HasIndex(e => e.LocationId, "location_id");

                entity.HasIndex(e => e.SpecialityId, "speciality_id");

                entity.Property(e => e.SymtomId).HasColumnName("symtom_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.SymtomName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("symtom_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Symtoms)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("symtom_ibfk_1");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Symtoms)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("symtom_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserStatusId, "user_status_id");

                entity.HasIndex(e => e.UserTypeId, "user_type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PasswordHashed)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("password_hashed");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserStatusId)
                    .HasColumnName("user_status_id")
                    .HasDefaultValueSql("'500'");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .HasConstraintName("users_ibfk_2");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_1");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("user_status");

                entity.Property(e => e.UserStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_status_id");

                entity.Property(e => e.UserStatusName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("user_status_name");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("user_types");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("user_type_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
