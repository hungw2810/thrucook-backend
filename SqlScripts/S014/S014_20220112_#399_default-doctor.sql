USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S014_20220112_#399_default-doctor');

ALTER TABLE `drcloud_main`.`doctor_settings` 
ADD COLUMN `number_of_appointments_per_slot` INT NOT NULL DEFAULT 1 AFTER `is_auto_approve_appointment`;
