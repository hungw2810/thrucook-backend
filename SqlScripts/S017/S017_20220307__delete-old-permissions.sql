USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S017_20220307__delete-old-permissions');

-- Delete
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '33') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '139') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '140') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '141') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '137') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '138') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '29') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '111') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '121') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '110') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '109') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '31') and (`frontend_screen_id` = '16');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '116') and (`frontend_screen_id` = '12');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '117') and (`frontend_screen_id` = '4');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '115') and (`frontend_screen_id` = '1');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '29') and (`frontend_screen_id` = '10');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '29') and (`frontend_screen_id` = '12');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '33') and (`frontend_screen_id` = '11');
-- screen permissions
DELETE FROM `drcloud_main`.`screen_permissions` WHERE `frontend_screen_id` = 16;
-- Delete Standard screen permissions
DELETE FROM `drcloud_main`.`standard_screen_permissions` WHERE `standard_screen_permission_id` = 40;
DELETE FROM `drcloud_main`.`standard_screen_permissions` WHERE `standard_screen_permission_id` = 44;
DELETE FROM `drcloud_main`.`standard_screen_permissions` WHERE `standard_screen_permission_id` = 48;
-- Delete obsolete APIs
DELETE FROM `drcloud_main`.`apis` WHERE `api_id` = 115;
DELETE FROM `drcloud_main`.`apis` WHERE `api_id` = 116;
DELETE FROM `drcloud_main`.`apis` WHERE `api_id` = 117;
DELETE FROM `drcloud_main`.`apis` WHERE `api_id` = 118;
DELETE FROM `drcloud_main`.`apis` WHERE `api_id` = 119;
DELETE FROM `drcloud_main`.`apis` WHERE `api_id` = 29;
-- Delete screens
DELETE FROM `drcloud_main`.`frontend_screens` WHERE `frontend_screen_id` = 16;