USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S011_20211201_#287-location-is-visible-for-booking');

-- add column `is_visible_for_booking` to table `locations`
ALTER TABLE `drcloud_main`.`locations` 
ADD COLUMN `is_visible_for_booking` TINYINT(1) NOT NULL DEFAULT 1 AFTER `country_id`;
