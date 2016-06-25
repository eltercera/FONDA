--Status
INSERT INTO [dbo].[STATUS] ([sta_id], [sta_type], [sta_description]) VALUES (1, N'ActiveSimpleStatus', N'Estado Activo Simple')
INSERT INTO [dbo].[STATUS] ([sta_id], [sta_type], [sta_description]) VALUES (2, N'DisableSimpleStatus', N'Estado simple Inactivo')
INSERT INTO [dbo].[STATUS] ([sta_id], [sta_type], [sta_description]) VALUES (6, N'FreeTableStatus', N'Mesa Disponible')
INSERT INTO [dbo].[STATUS] ([sta_id], [sta_type], [sta_description]) VALUES (7, N'CanceledReservationStatus', N'Reservacion Cancelada')
INSERT INTO [dbo].[STATUS] ([sta_id], [sta_type], [sta_description]) VALUES (8, N'ReservedReservationStatus', N'Reservacion Realizada')
--Day
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (1, N'Lunes')
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (2, N'Martes')
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (3, N'Miercoles')
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (4, N'Jueves')
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (5, N'Viernes')
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (6, N'Sabado')
INSERT INTO [dbo].[DAY] ([day_id], [day_name]) VALUES (7, N'Domingo')
--Restaurant Category

INSERT INTO [dbo].[RESTAURANT_CATEGORY] ([rc_id], [rc_name]) VALUES (1, N'China')
INSERT INTO [dbo].[RESTAURANT_CATEGORY] ([rc_id], [rc_name]) VALUES (2, N'Japonesa')
INSERT INTO [dbo].[RESTAURANT_CATEGORY] ([rc_id], [rc_name]) VALUES (3, N'Chatarra')
INSERT INTO [dbo].[RESTAURANT_CATEGORY] ([rc_id], [rc_name]) VALUES (4, N'Mexicana')
INSERT INTO [dbo].[RESTAURANT_CATEGORY] ([rc_id], [rc_name]) VALUES (5, N'Criolla')

--Zone
INSERT INTO [dbo].[ZONE] ([zon_id], [zon_name]) VALUES (1, N'Altamira')
INSERT INTO [dbo].[ZONE] ([zon_id], [zon_name]) VALUES (2, N'La Castellana')
INSERT INTO [dbo].[ZONE] ([zon_id], [zon_name]) VALUES (3, N'El Paraíso')
INSERT INTO [dbo].[ZONE] ([zon_id], [zon_name]) VALUES (4, N'Chacao')
INSERT INTO [dbo].[ZONE] ([zon_id], [zon_name]) VALUES (5, N'Montalban')
--Currency
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (1, N'Dolar', N'$')
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (2, N'Euro', N'€')
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (3, N'Bolivar Fuerte', N'BsF')
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (4, N'Real', N'R$')
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (5, N'Peso', N'$')
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (6, N'Franco', N'Fr')
INSERT INTO [dbo].[CURRENCY] ([cu_id], [cur_name], [cur_symbol]) VALUES (7, N'Libra', N'£')

--Schedule
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (1, 252000000000, 540000000000)
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (2, 252000000000, 720000000000)
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (3, 288000000000, 540000000000)
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (4, 252000000000, 792000000000)
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (5, 288000000000, 720000000000)
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (6, 432000000000, 756000000000)
INSERT INTO [dbo].[SCHEDULE] ([sch_id], [sch_openingTime], [sch_closingTime]) VALUES (7, 396000000000, 792000000000)

--Coordinate

INSERT INTO [dbo].[COORDINATE] ([coo_id], [coo_latitud], [coo_longitud]) VALUES (1, 10.494965, -66.925364)
INSERT INTO [dbo].[COORDINATE] ([coo_id], [coo_latitud], [coo_longitud]) VALUES (2, 10.492104, -66.814397)
INSERT INTO [dbo].[COORDINATE] ([coo_id], [coo_latitud], [coo_longitud]) VALUES (3, 10.493018, -66.925921)

--DaySchedule
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (1, 1)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (1, 2)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (1, 3)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (2, 4)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (2, 2)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (2, 3)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (3, 4)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (3, 5)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (3, 6)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (4, 7)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (4, 5)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (4, 6)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (4, 7)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (4, 1)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (5, 1)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (5, 2)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (5, 5)
INSERT INTO [dbo].[DayToSchedule] ([Schedule_id], [Day_id]) VALUES (5, 6)
--Restaurant
INSERT INTO [dbo].[RESTAURANT] ([res_id], [res_name], [res_nationality], [res_rif], [res_address], 
	[res_logo], [res_status], [fk_res_coordinate], [fk_res_currency], [fk_res_restaurantCategory], 
	[fk_res_zone], [fk_res_schedule]) VALUES (1, N'Tierra Mar', N'V', N'123456789', 
	N'Av. El ejercito con puente de San Juan', N'restaurantLogo.png', 1, 2, 2, 2, 2, 1)
INSERT INTO [dbo].[RESTAURANT] ([res_id], [res_name], [res_nationality], [res_rif], [res_address], 
	[res_logo], [res_status], [fk_res_coordinate], [fk_res_currency], [fk_res_restaurantCategory], 
	[fk_res_zone], [fk_res_schedule]) VALUES (2, N'El Mundo del Pollo', N'V', N'123458789', 
	N'Av. El Paez ', N'restaurantLogo.png', 1, 1, 1, 1, 1, 2)
INSERT INTO [dbo].[RESTAURANT] ([res_id], [res_name], [res_nationality], [res_rif], [res_address], 
	[res_logo], [res_status], [fk_res_coordinate], [fk_res_currency], [fk_res_restaurantCategory], 
	[fk_res_zone], [fk_res_schedule]) VALUES (3, N'Pizza Familia', N'V', N'123455789', 
	N'Av. 3 con Calle 3', N'restaurantLogo.png', 1, 3, 3, 3, 3, 3)
INSERT INTO [dbo].[RESTAURANT] ([res_id], [res_name], [res_nationality], [res_rif], [res_address], 
	[res_logo], [res_status], [fk_res_coordinate], [fk_res_currency], [fk_res_restaurantCategory], 
	[fk_res_zone], [fk_res_schedule]) VALUES (4, N'Burger Shack', N'V', N'123775575', 
	N'Av. Las Rosas', N'restaurantLogo.png', 1, 1, 4, 4, 4, 4)
INSERT INTO [dbo].[RESTAURANT] ([res_id], [res_name], [res_nationality], [res_rif], [res_address], 
	[res_logo], [res_status], [fk_res_coordinate], [fk_res_currency], [fk_res_restaurantCategory], 
	[fk_res_zone], [fk_res_schedule]) VALUES (5, N'La Toscana', N'V', N'123875557', 
	N'Calle Macuto', N'restaurantLogo.png', 1, 2, 5, 5, 5, 5)



--Table

INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (1, 2, 1, 6,1)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (2,2, 2, 6,1)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (3,4, 3, 6,1)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (4,4, 1, 6,2)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (5,6, 2, 6,2)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (6,6, 3, 6,2)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (7,2, 4, 6,2)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (8,2, 5, 6,2)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (9,2, 1, 6,3)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (10,4,2, 6,3)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (11,6, 3, 6,3)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (12,4, 4, 6,3)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (13,4, 5, 6,3)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (14,6, 6, 6,3)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (15,8, 1, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (16,2, 2, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (17,4, 3, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (18,4, 4, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (19,6, 5, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (20,8, 6, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (21,2, 7, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (22,2, 8, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (23,4, 9, 6,4)
INSERT INTO [dbo].[CTABLE] ([tab_id], [tab_capacity], [tab_number], [fk_tab_status], [fk_tab_restaurant]) VALUES (24,6, 10, 6,4)



---------------------- MENUCATEGORY ----------------
INSERT INTO [dbo].[MENUCATEGORY] ([cat_menu_id], [cat_menu_name], [fk_cat_status], [fk_res_mencat]) VALUES (1, N'Pastas', 1, 1)
INSERT INTO [dbo].[MENUCATEGORY] ([cat_menu_id], [cat_menu_name], [fk_cat_status], [fk_res_mencat]) VALUES (2, N'Carnes y Aves', 1, 2)
INSERT INTO [dbo].[MENUCATEGORY] ([cat_menu_id], [cat_menu_name], [fk_cat_status], [fk_res_mencat]) VALUES (3, N'Pescados y Mariscos', 1, 3)

---------------------- Dish -------------------------
---------------------- DISH (Pastas) ---------------
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (1, N'Pasta carbonara', N'Pasta con tocineta, crema y queso parmesano', NULL, 0, 2000, 1, 1)
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (2, N'Pasta marinera', N'Pasta con camarones y calamares', NULL, 1, 1950, 1, 1)
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (3, N'Pasta al pesto', N'Pasta con albahaca y aceite de oliva', NULL, 0, 1500, 1, 1)
----------------------DISH (Carnes) -----------------
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (4, N'Pollo a la plancha', N'Pollo cocinado a la plancha, acompañado con papas fritas', NULL, 0, 1100, 1, 2)
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (5, N'Bistek encebollado', N'Corte de carne cocinado con cebollas', NULL, 1, 1100, 1, 2)
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (6, N'Parrilla de carne', N'Parrilla de varios cortes acompañada con papas fritas', NULL, 0, 4000, 1, 2)
---------------------- DISH (Pescados) --------------
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (7, N'Salmon ahumado', N'Salmon cocinado al vapor', NULL, 0, 3900, 1, 3)
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (8, N'Mero a la plancha', N'Mero cocinado a la plancha', NULL, 1, 2500, 1, 3)
INSERT INTO [dbo].[DISH] ([dis_id], [dis_name], [dis_description], [dis_image], [dis_suggestion], [dis_cost], [fk_dis_status], [fk_menu_dish]) VALUES (9, N'Parrilla de mariscos', N'Parrilla de camarones, calamares, pulpo y chipi chipi', NULL, 0, 4200, 1, 3)

/*Insert UsertAccount*/
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (1, N'com.ds201625.fonda.Domain.UserAccount', N'fondamars@gmail.com', N'fondam12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (2, N'com.ds201625.fonda.Domain.UserAccount', N'fondamarc@gmail.com', N'fondam12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (3, N'com.ds201625.fonda.Domain.UserAccount', N'fondamundor@gmail.com', N'fondao2345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (4, N'com.ds201625.fonda.Domain.UserAccount', N'fondamundoc@gmail.com', N'fondao12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (5, N'com.ds201625.fonda.Domain.UserAccount', N'fondapizzar@gmail.com', N'fondap12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (6, N'com.ds201625.fonda.Domain.UserAccount', N'fondapizzac@gmail.com', N'fondap12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (7, N'com.ds201625.fonda.Domain.UserAccount', N'fondashackr@gmail.com', N'fondas12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (8, N'com.ds201625.fonda.Domain.UserAccount', N'fondashackc@gmail.com', N'fondas12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (9, N'com.ds201625.fonda.Domain.UserAccount', N'fondatoscanar@gmail.com', N'fondat12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (10, N'com.ds201625.fonda.Domain.UserAccount', N'fondatoscanac@gmail.com', N'fondat12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (11, N'com.ds201625.fonda.Domain.UserAccount', N'fonda@gmail.com', N'fondas12345')
INSERT INTO [dbo].[USER_ACCOUNT] ([ua_id], [ua_type], [gp_email], [gp_password]) VALUES (12, N'com.ds201625.fonda.Domain.UserAccount', N'fonda1@gmail.com', N'fondas12345')

/*Insert Rol*/
INSERT INTO [dbo].[ROLE] ([rol_id], [rol_name], [rol_descripcion]) VALUES (3, N'Sistema', N'Es el encargado de la gestión de restaurantes')
INSERT INTO [dbo].[ROLE] ([rol_id], [rol_name], [rol_descripcion]) VALUES (2, N'Restaurante', N'Es el encargado a todo lo referente a la labor interna del restaurante')
INSERT INTO [dbo].[ROLE] ([rol_id], [rol_name], [rol_descripcion]) VALUES (1, N'Caja', N'Es el encargado de llevar toda la gestión de Caja')

--Employee


--Restaurant Tierra Mar
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (1, N'Employee', N'Lucero', N'Av. Las Rosas', N'0416-99-97-378', N'V-9231238', 1, N'Garcia', N'F', N'1986-08-07 00:00:00', N'fondamarr', 1, 2, 1)
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (2, N'Employee', N'Jhon', N'Av. Paez', N'0412-11-63-457', N'V-18753948', 1, N'Canales ', N'M', N'1991-09-08 00:00:00', N'fondamarc', 2, 1, 1)
--Restaurant El Mundo del Pollo
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (3, N'Employee', N'Caridad', N'Colinas de club', N'0424-11-63-457', N'V-119874123', 1, N'Reyes', N'F', N'1991-08-08 00:00:00', N'fondamundor', 3, 2, 2)
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (4, N'Employee', N'Clemencia', N'El paraiso', N'0414-11-63-457', N'E-10854752', 1, N'Mark', N'F', N'1964-10-02 00:00:00', N'fondamundoc', 4, 1, 2)

--Restaurant Pizza Familia
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (5, N'Employee', N'Mathías', N' Av. Principal El Pedregal', N'0414-11-63-457', N'V-9856325', 1, N'Espinoza', N'M', N'1965-02-07 00:00:00', N'fondapizzar', 5, 2, 3)
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (6, N'Employee', N'Mateos', N'Urbanización La Castellana', N'0414-11-63-457', N'V-7598523', 1, N'Franco', N'M', N'1991-08-08 00:00:00', N'fondapizzac', 6, 1, 3)

--Restaurant Burger Shack
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (7, N'Employee', N'Iren', N'Av. Casanova, Edificio Carupano', N'0414-11-63-457', N'E-1458752', 1, N'Uribe', N'F', N'1973-03-04 00:00:00', N'fondashackr', 7, 2, 4)
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (8, N'Employee', N'Douglas', N'Urbanizacion Altagracia', N'0414-11-63-457', N'V-1235863', 1, N'Serrato', N'M', N'1994-07-06 00:00:00', N'fondashackc', 8, 1, 4)

--Restaurant La Toscana
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (9, N'Employee', N'Lukas', N'Urbanizacion el Valle', N'0414-11-63-457', N'E-478952', 1, N'Valverde', N'M', N'1990-05-06 00:00:00', N'fondatoscanar', 9, 2, 5)
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (10, N'Employee', N'Anastasie', N'Av. Libertador', N'0414-11-63-457', N'V-20130951', 1, N'González', N'F', N'1991-03-02 00:00:00', N'fondatoscanac', 10, 1, 5)

--Employee System
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (11, N'Employee', N'Mark', N'El Cafetal', N'0414-11-63-457', N'V-9158651', 1, N'Rodriquez', N'M', N'1991-08-08 00:00:00', N'fondas', 11, 3, NULL)
INSERT INTO [dbo].[GENERIC_PERSON] ([gp_id], [gp_type], [gp_name], [gp_address], [gp_phone_number], [gp_ssn], [fk_sinple_status_id], [per_last_name], [per_Gender], [per_birt_date], [emp_username], [fk_useraccount_id], [fk_role_employee], [fk_restaurant_id]) VALUES (12, N'Employee', N'Mary', N'Av. Abraham Lincoln', N'0414-11-63-457', N'E-19932801', 1, N'Hulsey', N'M', N'1989-03-03 00:00:00', N'fondas1', 12, 3, NULL)

---------Reservations--------------
INSERT INTO [dbo].[RESERVATION] ([res_id], [res_number], [res_date], [res_createDate], [res_commensalNumber], [fk_res_status], [fk_res_restaurant], [fk_res_table]) VALUES (1, 1, N'2016-07-10 00:00:00', N'2016-07-01 00:00:00', 2, 8, NULL, NULL)
INSERT INTO [dbo].[RESERVATION] ([res_id], [res_number], [res_date], [res_createDate], [res_commensalNumber], [fk_res_status], [fk_res_restaurant], [fk_res_table]) VALUES (2, 2, N'2016-07-11 00:00:00', N'2016-07-01 00:00:00', 4, 7, NULL, NULL)
INSERT INTO [dbo].[RESERVATION] ([res_id], [res_number], [res_date], [res_createDate], [res_commensalNumber], [fk_res_status], [fk_res_restaurant], [fk_res_table]) VALUES (3, 3, N'2016-07-12 00:00:00', N'2016-07-01 00:00:00', 6, 8, NULL, NULL)
INSERT INTO [dbo].[RESERVATION] ([res_id], [res_number], [res_date], [res_createDate], [res_commensalNumber], [fk_res_status], [fk_res_restaurant], [fk_res_table]) VALUES (4, 4, N'2016-07-13 00:00:00', N'2016-07-01 00:00:00', 8, 7, NULL, NULL)
INSERT INTO [dbo].[RESERVATION] ([res_id], [res_number], [res_date], [res_createDate], [res_commensalNumber], [fk_res_status], [fk_res_restaurant], [fk_res_table]) VALUES (5, 5, N'2016-07-14 00:00:00', N'2016-07-01 00:00:00', 8, 8, NULL, NULL)


-----------Reservation_Commensal---------
INSERT INTO [dbo].[RESERVATION_COMMENSAL] ([Commensal_id], [Reservation_id]) VALUES (1, 1)
INSERT INTO [dbo].[RESERVATION_COMMENSAL] ([Commensal_id], [Reservation_id]) VALUES (1, 2)
INSERT INTO [dbo].[RESERVATION_COMMENSAL] ([Commensal_id], [Reservation_id]) VALUES (2, 3)
INSERT INTO [dbo].[RESERVATION_COMMENSAL] ([Commensal_id], [Reservation_id]) VALUES (2, 4)
INSERT INTO [dbo].[RESERVATION_COMMENSAL] ([Commensal_id], [Reservation_id]) VALUES (3, 5)

----------Reservation_Table---------------
INSERT INTO [dbo].[RESERVATION_TABLE] ([Table_id], [Reservation_id]) VALUES (1, 1)
INSERT INTO [dbo].[RESERVATION_TABLE] ([Table_id], [Reservation_id]) VALUES (3, 2)
INSERT INTO [dbo].[RESERVATION_TABLE] ([Table_id], [Reservation_id]) VALUES (5, 3)
INSERT INTO [dbo].[RESERVATION_TABLE] ([Table_id], [Reservation_id]) VALUES (15, 4)
INSERT INTO [dbo].[RESERVATION_TABLE] ([Table_id], [Reservation_id]) VALUES (20, 5)

