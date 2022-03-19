namespace Thucook.Main.ApiModel.ApiErrorMessages
{
    /// <summary>
    /// Prefix must be: PINT_
    /// </summary>
    public static class ApiInternalErrorMessages
    {
        public static ApiErrorMessage LoginFailed => new ApiErrorMessage
        {
            Code = "PINT_1001",
            Value = "Login failed"
        };

        public static ApiErrorMessage PhoneAlreadyUsed => new ApiErrorMessage
        {
            Code = "PINT_1002",
            Value = "The phone number is already used"
        };

        public static ApiErrorMessage UserNotVerified => new ApiErrorMessage
        {
            Code = "PINT_1003",
            Value = "The user is not verified yet"
        };

        public static ApiErrorMessage TokenError => new ApiErrorMessage
        {
            Code = "PINT_1004",
            Value = "Token error"
        };

        public static ApiErrorMessage ConfirmationCodeExpired => new ApiErrorMessage
        {
            Code = "PINT_1005",
            Value = "Confirmation code already expired"
        };

        public static ApiErrorMessage DuplicateName => new ApiErrorMessage
        {
            Code = "PINT_1006",
            Value = "Duplicate name"
        };

        public static ApiErrorMessage AppoitmentAlreadyFinished => new ApiErrorMessage
        {
            Code = "PINT_1007",
            Value = "Appoitment Already Finished"
        };

        public static ApiErrorMessage CancelReasonRequired => new ApiErrorMessage
        {
            Code = "PINT_1008",
            Value = "Cancel reason is required"
        };

        public static ApiErrorMessage StatusNotAllowed => new ApiErrorMessage
        {
            Code = "PINT_1009",
            Value = "Status not allowed"
        };

        public static ApiErrorMessage EmailAlreadyUsed => new ApiErrorMessage
        {
            Code = "PINT_1010",
            Value = "The email is already used"
        };

        public static ApiErrorMessage WrongPassword => new ApiErrorMessage
        {
            Code = "PINT_1011",
            Value = "Wrong password"
        };

        public static ApiErrorMessage ScheduleOverlap => new ApiErrorMessage
        {
            Code = "PINT_1012",
            Value = "Schedule overlaps with current ones"
        };

        public static ApiErrorMessage PastTimeNotAllowed => new ApiErrorMessage
        {
            Code = "PINT_1013",
            Value = "Past time not allowed"
        };

        public static ApiErrorMessage OccupiedAppointments => new ApiErrorMessage
        {
            Code = "PINT_1014",
            Value = "The schedule has occupied appointments"
        };

        public static ApiErrorMessage DuplicateDoctorCode => new ApiErrorMessage
        {
            Code = "PINT_1015",
            Value = "Duplicate DoctorCode"
        };

        public static ApiErrorMessage CannotDeleteOwner => new ApiErrorMessage
        {
            Code = "PINT_1016",
            Value = "Cannot delete Owner's profile"
        };

        public static ApiErrorMessage CannotEditOwner => new ApiErrorMessage
        {
            Code = "PINT_1017",
            Value = "Cannot edit Owner's profile"
        };

        public static ApiErrorMessage CannotDeleteOwnerAdminRole => new ApiErrorMessage
        {
            Code = "PINT_1018",
            Value = "Cannot delete Owner/Admin role"
        };

        public static ApiErrorMessage CannotEditOwnerAdminRole => new ApiErrorMessage
        {
            Code = "PINT_1019",
            Value = "Cannot edit Owner/Admin role"
        };

        public static ApiErrorMessage ExistedEmail => new ApiErrorMessage
        {
            Code = "PINT_1020",
            Value = "Email already existed"
        };

        public static ApiErrorMessage OwnerOnly => new ApiErrorMessage
        {
            Code = "PINT_1021",
            Value = "Only owner of the clinic can commit this action"
        };

        public static ApiErrorMessage OwnerPassword => new ApiErrorMessage
        {
            Code = "PINT_1022",
            Value = "You can not change password of owner"
        };

        public static ApiErrorMessage AppointmentTimeNotAvailable => new ApiErrorMessage
        {
            Code = "PINT_1023",
            Value = "Appointment time is not available"
        };

        public static ApiErrorMessage UserAlreadyVerified => new ApiErrorMessage
        {
            Code = "PINT_1024",
            Value = "User is already verified"
        };

        public static ApiErrorMessage ScheduleDurationTooLong => new ApiErrorMessage
        {
            Code = "PINT_1025",
            Value = "Schedule duration is too long"
        };

        public static ApiErrorMessage LateCheckIn => new ApiErrorMessage
        {
            Code = "PINT_1026",
            Value = "Late check-in"
        };

        public static ApiErrorMessage CheckInTooSoon => new ApiErrorMessage
        {
            Code = "PINT_1027",
            Value = "Check-in too soon"
        };

        public static ApiErrorMessage FileCorrupted => new ApiErrorMessage
        {
            Code = "PINT_1028",
            Value = "File corrupted"
        };

        public static ApiErrorMessage DuplicatePatient => new ApiErrorMessage
        {
            Code = "PINT_1029",
            Value = "Duplicate Patient In This Slot"
        };

        public static ApiErrorMessage ListOfOptionsDuplicated => new ApiErrorMessage
        {
            Code = "PINT_1030",
            Value = "List Of Options Duplicate"
        };

        public static ApiErrorMessage ListOfOptionsCannotNull => new ApiErrorMessage
        {
            Code = "PINT_1031",
            Value = "List Of Options Can Not Null"
        };

        public static ApiErrorMessage CannotEditDefaultProperty => new ApiErrorMessage
        {
            Code = "PINT_1032",
            Value = "Cannot Edit Default Property"
        };

        public static ApiErrorMessage DuplicateInternalName => new ApiErrorMessage
        {
            Code = "PINT_1033",
            Value = "Duplicate Internal Name"
        };

        public static ApiErrorMessage DuplicateFormName => new ApiErrorMessage
        {
            Code = "PINT_1034",
            Value = "Duplicate Form Name"
        };

        public static ApiErrorMessage DuplicateMedicine => new ApiErrorMessage
        {
            Code = "PINT_1035",
            Value = "Duplicate Medicine"
        };

        public static ApiErrorMessage TooMuchAppointmentsAtSameTime => new ApiErrorMessage
        {
            Code = "PINT_1036",
            Value = "Too Much Appointments At Same Time"
        };

        public static ApiErrorMessage TooMuchAppointmentsOnSameDay => new ApiErrorMessage
        {
            Code = "PINT_1037",
            Value = "Too Much Appointments On Same Day"
        };

        public static ApiErrorMessage DuplicateShortName => new ApiErrorMessage
        {
            Code = "PINT_1038",
            Value = "Duplicate short name"
        };

        public static ApiErrorMessage DoctorNotAvailable => new ApiErrorMessage
        {
            Code = "PINT_1040",
            Value = "Doctor Not Available"
        };

        public static ApiErrorMessage CannotEditDefaultForm => new ApiErrorMessage
        {
            Code = "PINT_1041",
            Value = "Cannot Edit Default Form"
        };

        public static ApiErrorMessage DuplicateCustomerCode => new ApiErrorMessage
        {
            Code = "PINT_1042",
            Value = "Duplicate Customer Code"
        };

        // NOT FOUND ERROR
        public static ApiErrorMessage AppointmentNotFound => new ApiErrorMessage
        {
            Code = "PINT_4001",
            Value = "Appointment Not Found"
        };

        public static ApiErrorMessage ClinicNotFound => new ApiErrorMessage
        {
            Code = "PINT_4002",
            Value = "Clinic Not Found"
        };

        public static ApiErrorMessage ClinicPatientNotFound => new ApiErrorMessage
        {
            Code = "PINT_4003",
            Value = "Clinic Patient Not Found"
        };

        public static ApiErrorMessage DoctorNotFound => new ApiErrorMessage
        {
            Code = "PINT_4004",
            Value = "Doctor Not Found"
        };

        public static ApiErrorMessage EmployeeNotFound => new ApiErrorMessage
        {
            Code = "PINT_4005",
            Value = "Employee Not Found"
        };

        public static ApiErrorMessage LocationNotFound => new ApiErrorMessage
        {
            Code = "PINT_4006",
            Value = "Location Not Found"
        };

        public static ApiErrorMessage PatientNotFound => new ApiErrorMessage
        {
            Code = "PINT_4007",
            Value = "Patient Not Found"
        };

        public static ApiErrorMessage ScheduleNotFound => new ApiErrorMessage
        {
            Code = "PINT_4008",
            Value = "Schedule Not Found"
        };

        public static ApiErrorMessage SpecialtyNotFound => new ApiErrorMessage
        {
            Code = "PINT_4009",
            Value = "Specialty Not Found"
        };

        public static ApiErrorMessage SymptonNotFound => new ApiErrorMessage
        {
            Code = "PINT_4010",
            Value = "Sympton Not Found"
        };

        public static ApiErrorMessage UserInfoNotFound => new ApiErrorMessage
        {
            Code = "PINT_4011",
            Value = "User Info Not Found"
        };

        public static ApiErrorMessage UserGroupNotFound => new ApiErrorMessage
        {
            Code = "PINT_4012",
            Value = "User Group Not Found"
        };

        public static ApiErrorMessage RoleNotFound => new ApiErrorMessage
        {
            Code = "PINT_4013",
            Value = "Role Not Found"
        };

        public static ApiErrorMessage UserNotFound => new ApiErrorMessage
        {
            Code = "PINT_4014",
            Value = "User Not Found"
        };

        public static ApiErrorMessage NotificationNotFound => new ApiErrorMessage
        {
            Code = "PINT_4015",
            Value = "Notification Not Found"
        };

        public static ApiErrorMessage PhysicalFileNotFound => new ApiErrorMessage
        {
            Code = "PINT_4016",
            Value = "Physical File Not Found"
        };

        public static ApiErrorMessage MedicineNotFound => new ApiErrorMessage
        {
            Code = "PINT_4017",
            Value = "Medicine Not Found"
        };

        public static ApiErrorMessage PropertyNotFound => new ApiErrorMessage
        {
            Code = "PINT_4018",
            Value = "Property Not Found"
        };

        public static ApiErrorMessage FormNotFound => new ApiErrorMessage
        {
            Code = "PINT_4019",
            Value = "Form Not Found"
        };

        public static ApiErrorMessage ResultSheetNotFound => new ApiErrorMessage
        {
            Code = "PINT_4020",
            Value = "Result Sheet Not Found"
        };

        // INVALID ERROR
        public static ApiErrorMessage InvalidConfirmationInput => new ApiErrorMessage
        {
            Code = "PINT_5001",
            Value = "Invalid confirmation input"
        };

        public static ApiErrorMessage InvalidStatus => new ApiErrorMessage
        {
            Code = "PINT_5002",
            Value = "Invalid Status"
        };

        public static ApiErrorMessage InvalidAppointmentTime => new ApiErrorMessage
        {
            Code = "PINT_5003",
            Value = "Invalid Appointment Time"
        };

        public static ApiErrorMessage InvalidEmail => new ApiErrorMessage
        {
            Code = "PINT_5004",
            Value = "Invalid Email"
        };

        public static ApiErrorMessage InvalidSkill => new ApiErrorMessage
        {
            Code = "PINT_5005",
            Value = "Invalid Skill"
        };

        public static ApiErrorMessage InvalidEditDoctorScheduleCase => new ApiErrorMessage
        {
            Code = "PINT_5006",
            Value = "Invalid Edit Doctor Schedule Case"
        };

        public static ApiErrorMessage InvalidUsernameOrPassword => new ApiErrorMessage
        {
            Code = "PINT_5007",
            Value = "Invalid username or password"
        };

        public static ApiErrorMessage InvalidConfirmationCode => new ApiErrorMessage
        {
            Code = "PINT_5008",
            Value = "Invalid confirmation code"
        };

        public static ApiErrorMessage InvalidPhoneNumber => new ApiErrorMessage
        {
            Code = "PINT_5009",
            Value = "Invalid phone number"
        };

        public static ApiErrorMessage InvalidSignupCode => new ApiErrorMessage
        {
            Code = "PINT_5010",
            Value = "Invalid sign-up code"
        };

        public static ApiErrorMessage InvalidRecurrenceString => new ApiErrorMessage
        {
            Code = "PINT_5011",
            Value = "Invalid Recurrence String"
        };

        public static ApiErrorMessage InvalidDateRange => new ApiErrorMessage
        {
            Code = "PINT_5012",
            Value = "Invalid Date Range"
        };

        public static ApiErrorMessage InvalidRole => new ApiErrorMessage
        {
            Code = "PINT_5013",
            Value = "Invalid Role"
        };

        public static ApiErrorMessage InvalidFileExtension => new ApiErrorMessage
        {
            Code = "PINT_5014",
            Value = "Invalid File Extension"
        };

        public static ApiErrorMessage InvalidPhysicalFileType => new ApiErrorMessage
        {
            Code = "PINT_5015",
            Value = "Invalid Physical File Type"
        };

        public static ApiErrorMessage InvalidValueType => new ApiErrorMessage
        {
            Code = "PINT_5016",
            Value = "Invalid Value Type"
        };

        public static ApiErrorMessage InvalidReExaminationDate => new ApiErrorMessage
        {
            Code = "PINT_5017",
            Value = "Invalid Re-Examination Date"
        };

        public static ApiErrorMessage InvalidMBLoginToken => new ApiErrorMessage
        {
            Code = "PINT_5018",
            Value = "Invalid MB Login Token"
        };
    }
}
