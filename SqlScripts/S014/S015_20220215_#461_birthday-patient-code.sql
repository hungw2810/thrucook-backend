USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S015_20220215_#461_birthday-patient-code');

ALTER TABLE drcloud_main.user_informations MODIFY COLUMN birthday datetime NULL;
ALTER TABLE drcloud_main.patients MODIFY COLUMN birthday datetime NOT NULL;
ALTER TABLE drcloud_main.clinic_patients MODIFY COLUMN birthday datetime NOT NULL;

ALTER TABLE drcloud_main.clinic_patients DROP INDEX patient_code_clinic_patient_code_idx;

ALTER TABLE appointments ADD INDEX appointment_status_id_idx (appointment_status_id);