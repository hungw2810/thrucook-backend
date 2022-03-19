USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S018_20220313__delete-old-permissions');

ALTER TABLE `drcloud_main`.`clinics` 
DROP COLUMN `is_deleted`;
