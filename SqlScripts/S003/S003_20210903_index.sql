USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S003_20210903_index');

ALTER TABLE locations ADD FULLTEXT location_name_idx (location_name);

ALTER TABLE specialties ADD FULLTEXT specialty_name_idx (specialty_name);

ALTER TABLE symptoms ADD FULLTEXT symptom_name_idx (symptom_name);

ALTER TABLE doctors ADD FULLTEXT doctor_name_idx (doctor_name);

ALTER TABLE patients ADD UNIQUE patient_sequence_idx (patient_sequence DESC);

ALTER TABLE doctors ADD UNIQUE doctor_sequence_idx (doctor_sequence DESC);

ALTER TABLE clinic_patients ADD FULLTEXT full_name_phone_number_email_idx (full_name,phone_number, email)

ALTER TABLE clinic_patients ADD FULLTEXT patient_code_clinic_patient_code_idx (patient_code, clinic_patient_code)

ALTER TABLE clinic_patients ADD UNIQUE clinic_patient_sequence_idx (clinic_patient_sequence DESC);

ALTER TABLE appointments ADD INDEX appointment_code_idx (appointment_code);
