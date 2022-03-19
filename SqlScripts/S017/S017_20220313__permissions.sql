USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S017_20220313__permissions');

INSERT INTO `user_status` (`user_status_id`, `user_status_name`) VALUES ('600', 'WaitForPassword');

INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (151,11);