USE drcloud_main;
INSERT INTO `__migrations_history` (`migration_id`) VALUES ('S013_20220106_#328_permission');

INSERT INTO `drcloud_main`.`frontend_screens` (`frontend_screen_id`, `frontend_screen_name`) VALUES ('12', 'Dashboards - Patient Listing');

INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (34,1,12,20,0);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (35,2,12,20,1);
INSERT INTO `drcloud_main`.`standard_screen_permissions` (`standard_screen_permission_id`,`standard_role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`) VALUES (36,3,12,20,1);

INSERT INTO `drcloud_main`.`screen_permissions`(`clinic_id`, `role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`)
SELECT r.clinic_id, r.role_id, 12, 20, 0 FROM `drcloud_main`.`roles` AS r WHERE r.`role_type_id`=10;
INSERT INTO `drcloud_main`.`screen_permissions`(`clinic_id`, `role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`)
SELECT r.clinic_id, r.role_id, 12, 20, 1 FROM `drcloud_main`.`roles` AS r WHERE r.`role_type_id`=20;
INSERT INTO `drcloud_main`.`screen_permissions`(`clinic_id`, `role_id`,`frontend_screen_id`,`permission_type_id`,`is_editable`)
SELECT r.clinic_id, r.role_id, 12, 20, 1 FROM `drcloud_main`.`roles` AS r WHERE r.`role_type_id`=30;

DELETE FROM `drcloud_main`.`frontend_feature_api_mapping` WHERE (`api_id` = '27') and (`frontend_feature_id` = '102');
DELETE FROM `drcloud_main`.`frontend_feature_api_mapping` WHERE (`api_id` = '27') and (`frontend_feature_id` = '103');
DELETE FROM `drcloud_main`.`frontend_feature_api_mapping` WHERE (`api_id` = '27') and (`frontend_feature_id` = '104');
DELETE FROM `drcloud_main`.`frontend_feature_api_mapping` WHERE (`api_id` = '27') and (`frontend_feature_id` = '105');

INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (107,'Approve Appointment (Auth policies: ClinicOnly)',1,3,'clinic-appointments/approve',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (108,'Check-in Appointment (Auth policies: ClinicOnly)',1,3,'clinic-appointments/{appointmentId}/check-in',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (109,'Start Appointment (Auth policies: ClinicOnly)',1,3,'clinic-appointments/{appointmentId}/start',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (110,'Finish Appointment (Auth policies: ClinicOnly)',1,3,'clinic-appointments/{appointmentId}/finish',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (111,'Cancel Appointment (Auth policies: ClinicOnly)',1,3,'clinic-appointments/cancel',20,0,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (112,'Search patients of the clinic with paging (Auth policies: ClinicOnly)',1,2,'clinic-patients/search',10,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (113,'Delete a clinic patient (Auth policies: ClinicOnly)',1,4,'clinic-patients/{clinicPatientId}',20,20,0);

INSERT INTO `drcloud_main`.`frontend_feature_api_mapping`(`frontend_feature_id`,`api_id`) VALUES (102,107);
INSERT INTO `drcloud_main`.`frontend_feature_api_mapping`(`frontend_feature_id`,`api_id`) VALUES (103,108);
INSERT INTO `drcloud_main`.`frontend_feature_api_mapping`(`frontend_feature_id`,`api_id`) VALUES (104,109);
INSERT INTO `drcloud_main`.`frontend_feature_api_mapping`(`frontend_feature_id`,`api_id`) VALUES (104,110);
INSERT INTO `drcloud_main`.`frontend_feature_api_mapping`(`frontend_feature_id`,`api_id`) VALUES (105,111);


DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '27') and (`frontend_screen_id` = '10');
DELETE FROM `drcloud_main`.`frontend_screen_api_mapping` WHERE (`api_id` = '27') and (`frontend_screen_id` = '11');

INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (107,10);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (108,10);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (111,10);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (109,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (110,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (111,11);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (37,12);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (38,12);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (39,12);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (29,12);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (112,12);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (113,12);


INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (114,'Request presigned url to upload image',1,2,'files/request-upload-image',20,20,20);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (115,'Update new logo after uploaded (Auth policies: ClinicOnly)',1,3,'clinics/update-logo',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (116,'Update new avatar after uploaded (Auth policies: ClinicOnly)',1,3,'clinic-patients/{clinicPatientId}/update-avatar',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (117,'Update new avatar after uploaded (Auth policies: ClinicOnly)',1,3,'doctors/{doctorId}/update-avatar',20,10,0);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (118,'Update new avatar after uploaded (Auth policies: PatientOnly)',1,3,'patients/{patientId}/update-avatar',20,0,20);
INSERT INTO `drcloud_main`.`apis` (`api_id`,`api_name`,`api_service_id`,`api_method_type_id`,`api_route`,`api_action_type_id`,`default_permission_type_id`,`patient_default_permission_type_id`) VALUES (119,'Update new avatar after uploaded (Auth)',1,3,'users/update-avatar',20,20,20);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (114,1);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (115,1);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (114,4);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (117,4);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (114,12);
INSERT INTO `drcloud_main`.`frontend_screen_api_mapping`(`api_id`,`frontend_screen_id`) VALUES (116,12);
