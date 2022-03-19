USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S011_20211201_#294-standardise-data-types');

-- tinyint -> smallint
ALTER TABLE `drcloud_main`.`languages` 
CHANGE COLUMN `language_id` `language_id` SMALLINT NOT NULL ;

ALTER TABLE `drcloud_main`.`fcm_device_tokens` 
CHANGE COLUMN `language_id` `language_id` SMALLINT NOT NULL ;

-- bit(1) -> tinyint(1)
ALTER TABLE `drcloud_main`.`signup_codes`
CHANGE COLUMN `is_available` `is_available` tinyint(1) NOT NULL DEFAULT 1;

ALTER TABLE `drcloud_main`.`users`
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`patients`
CHANGE COLUMN `is_default` `is_default` tinyint(1) NOT NULL,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`clinics`
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`locations`
CHANGE COLUMN `is_enabled` `is_enabled` tinyint(1) NOT NULL DEFAULT 1,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`specialties`
CHANGE COLUMN `is_enabled` `is_enabled` tinyint(1) NOT NULL DEFAULT 1,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`symptoms`
CHANGE COLUMN `is_enabled` `is_enabled` tinyint(1) NOT NULL DEFAULT 1,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`doctors`
CHANGE COLUMN `is_enabled` `is_enabled` tinyint(1) NOT NULL DEFAULT 1,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`doctor_settings`
CHANGE COLUMN `is_visible_for_booking` `is_visible_for_booking` tinyint(1) NOT NULL DEFAULT 1,
CHANGE COLUMN `is_auto_approve_appointment` `is_auto_approve_appointment` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`doctor_schedules`
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`clinic_patients`
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`notification_objects`
CHANGE COLUMN `is_sent` `is_sent` tinyint(1) NOT NULL DEFAULT 0,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;

ALTER TABLE `drcloud_main`.`notifications`
CHANGE COLUMN `is_read` `is_read` tinyint(1) NOT NULL DEFAULT 0,
CHANGE COLUMN `is_deleted` `is_deleted` tinyint(1) NOT NULL DEFAULT 0;
