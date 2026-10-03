-- =====================================================================
-- PROYECTO INTEGRADOR - Sistema de Administración de Club Deportivo
-- Base de datos: Proyecto  |  Motor: MySQL 8.x  |  Charset: utf8mb4
-- =====================================================================

DROP DATABASE IF EXISTS Proyecto;
CREATE DATABASE Proyecto CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci;
USE Proyecto;

-- ---------------------------------------------------------------------
-- TABLA: persona  (datos comunes a Socio, NoSocio y Profesor)
-- ---------------------------------------------------------------------
CREATE TABLE persona (
    id_persona        INT AUTO_INCREMENT PRIMARY KEY,
    nombre            VARCHAR(60)  NOT NULL,
    apellido          VARCHAR(60)  NOT NULL,
    dni               VARCHAR(15)  NOT NULL UNIQUE,
    fecha_nacimiento  DATE         NOT NULL,
    telefono          VARCHAR(30),
    direccion         VARCHAR(120),
    email             VARCHAR(120)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: socio
-- ---------------------------------------------------------------------
CREATE TABLE socio (
    id_socio          INT AUTO_INCREMENT PRIMARY KEY,
    id_persona        INT NOT NULL UNIQUE,
    nro_socio         VARCHAR(20) NOT NULL UNIQUE,
    fecha_alta        DATE NOT NULL,
    apto_fisico       TINYINT(1) NOT NULL DEFAULT 0,
    estado            ENUM('Activo','Inactivo') NOT NULL DEFAULT 'Activo',
    carnet_entregado  TINYINT(1) NOT NULL DEFAULT 0,
    CONSTRAINT fk_socio_persona FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: profesor  (titulares y suplentes)
-- ---------------------------------------------------------------------
CREATE TABLE profesor (
    id_profesor         INT AUTO_INCREMENT PRIMARY KEY,
    id_persona          INT NOT NULL UNIQUE,
    legajo              VARCHAR(20) NOT NULL UNIQUE,
    especialidad        VARCHAR(80),
    tipo                ENUM('Titular','Suplente') NOT NULL DEFAULT 'Titular',
    horarios_asignados  VARCHAR(200),
    CONSTRAINT fk_profesor_persona FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: no_socio
-- ---------------------------------------------------------------------
CREATE TABLE no_socio (
    id_no_socio  INT AUTO_INCREMENT PRIMARY KEY,
    id_persona   INT NOT NULL,
    CONSTRAINT fk_nosocio_persona FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: actividad
-- ---------------------------------------------------------------------
CREATE TABLE actividad (
    id_actividad     INT AUTO_INCREMENT PRIMARY KEY,
    nombre           VARCHAR(80) NOT NULL,
    tipo             VARCHAR(50),
    costo_no_socio   DECIMAL(10,2) NOT NULL DEFAULT 0,
    horario          VARCHAR(80),
    cupo_maximo      INT NOT NULL DEFAULT 0,
    id_profesor      INT NULL,
    CONSTRAINT fk_actividad_profesor FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: inscripcion  (socio o no socio -> actividad)
-- ---------------------------------------------------------------------
CREATE TABLE inscripcion (
    id_inscripcion  INT AUTO_INCREMENT PRIMARY KEY,
    id_persona      INT NOT NULL,
    id_actividad    INT NOT NULL,
    fecha           DATE NOT NULL,
    tipo            ENUM('Socio','NoSocio') NOT NULL,
    apto_fisico     TINYINT(1) NOT NULL DEFAULT 0,
    monto_pagado    DECIMAL(10,2) NOT NULL DEFAULT 0,
    CONSTRAINT fk_inscripcion_persona   FOREIGN KEY (id_persona)   REFERENCES persona(id_persona),
    CONSTRAINT fk_inscripcion_actividad FOREIGN KEY (id_actividad) REFERENCES actividad(id_actividad)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: cuota
-- ---------------------------------------------------------------------
CREATE TABLE cuota (
    id_cuota           INT AUTO_INCREMENT PRIMARY KEY,
    id_socio           INT NOT NULL,
    mes                INT NOT NULL,
    anio               INT NOT NULL,
    monto              DECIMAL(10,2) NOT NULL,
    fecha_vencimiento  DATE NOT NULL,
    fecha_pago         DATE NULL,
    forma_pago         ENUM('Efectivo','Tarjeta') NULL,
    cuotas_tarjeta     INT NULL,
    CONSTRAINT fk_cuota_socio FOREIGN KEY (id_socio) REFERENCES socio(id_socio),
    INDEX idx_cuota_socio_periodo (id_socio, anio, mes)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: carnet
-- ---------------------------------------------------------------------
CREATE TABLE carnet (
    id_carnet          INT AUTO_INCREMENT PRIMARY KEY,
    id_socio           INT NOT NULL UNIQUE,
    fecha_emision      DATE NOT NULL,
    fecha_vencimiento  DATE NOT NULL,
    CONSTRAINT fk_carnet_socio FOREIGN KEY (id_socio) REFERENCES socio(id_socio)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: rutina
-- ---------------------------------------------------------------------
CREATE TABLE rutina (
    id_rutina    INT AUTO_INCREMENT PRIMARY KEY,
    id_profesor  INT NOT NULL,
    id_socio     INT NOT NULL,
    descripcion  TEXT NOT NULL,
    fecha        DATE NOT NULL,
    CONSTRAINT fk_rutina_profesor FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor),
    CONSTRAINT fk_rutina_socio    FOREIGN KEY (id_socio)    REFERENCES socio(id_socio)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: asistencia_profesor  (planilla de firma diaria)
-- ---------------------------------------------------------------------
CREATE TABLE asistencia_profesor (
    id_asistencia  INT AUTO_INCREMENT PRIMARY KEY,
    id_profesor    INT NOT NULL,
    fecha          DATE NOT NULL,
    hora_entrada   TIME NOT NULL,
    CONSTRAINT fk_asistencia_profesor FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor),
    CONSTRAINT uq_asistencia_dia UNIQUE (id_profesor, fecha)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: sueldo  (liquidación mensual, último día hábil del mes)
-- ---------------------------------------------------------------------
CREATE TABLE sueldo (
    id_sueldo    INT AUTO_INCREMENT PRIMARY KEY,
    id_profesor  INT NOT NULL,
    mes          INT NOT NULL,
    anio         INT NOT NULL,
    monto        DECIMAL(10,2) NOT NULL,
    fecha_pago   DATE NULL,
    CONSTRAINT fk_sueldo_profesor FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor),
    CONSTRAINT uq_sueldo_periodo UNIQUE (id_profesor, mes, anio)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: consulta_nutricion
-- ---------------------------------------------------------------------
CREATE TABLE consulta_nutricion (
    id_consulta                 INT AUTO_INCREMENT PRIMARY KEY,
    id_socio                    INT NOT NULL,
    fecha                       DATE NOT NULL,
    hora                        TIME NOT NULL,
    turno                       INT NOT NULL,
    observaciones               TEXT,
    carga_actividad_permitida   VARCHAR(200),
    CONSTRAINT fk_consulta_socio FOREIGN KEY (id_socio) REFERENCES socio(id_socio)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- TABLA: usuario  (login / control de acceso por rol)
-- ---------------------------------------------------------------------
CREATE TABLE usuario (
    id_usuario        INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario    VARCHAR(40)  NOT NULL UNIQUE,
    contrasena_hash   VARCHAR(255) NOT NULL,
    rol               ENUM('Administrador','Recepcionista','Profesor','Nutricionista') NOT NULL,
    id_persona        INT NULL,
    activo            TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT fk_usuario_persona FOREIGN KEY (id_persona) REFERENCES persona(id_persona)
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- ÍNDICES adicionales (búsquedas frecuentes / reportes)
-- ---------------------------------------------------------------------
CREATE INDEX idx_cuota_vencimiento   ON cuota(fecha_vencimiento);
CREATE INDEX idx_persona_apellido    ON persona(apellido);
CREATE INDEX idx_asistencia_fecha    ON asistencia_profesor(fecha);
CREATE INDEX idx_consulta_fecha      ON consulta_nutricion(fecha);

-- =====================================================================
-- STORED PROCEDURES (operaciones críticas)
-- =====================================================================
DELIMITER $$

-- Alta de socio: crea la persona y el registro de socio en una sola transacción lógica
CREATE PROCEDURE sp_AltaSocio(
    IN p_nombre        VARCHAR(60),
    IN p_apellido      VARCHAR(60),
    IN p_dni           VARCHAR(15),
    IN p_fecnac        DATE,
    IN p_telefono      VARCHAR(30),
    IN p_direccion     VARCHAR(120),
    IN p_email         VARCHAR(120),
    IN p_nrosocio      VARCHAR(20),
    IN p_aptofisico    TINYINT(1)
)
BEGIN
    DECLARE v_id_persona INT;
    DECLARE v_id_socio   INT;

    -- Si falla cualquiera de los dos INSERT se deshace todo (no quedan personas huérfanas)
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO persona (nombre, apellido, dni, fecha_nacimiento, telefono, direccion, email)
    VALUES (p_nombre, p_apellido, p_dni, p_fecnac, p_telefono, p_direccion, p_email);

    SET v_id_persona = LAST_INSERT_ID();

    INSERT INTO socio (id_persona, nro_socio, fecha_alta, apto_fisico, estado, carnet_entregado)
    VALUES (v_id_persona, p_nrosocio, CURDATE(), p_aptofisico, 'Activo', 0);

    SET v_id_socio = LAST_INSERT_ID();

    COMMIT;

    SELECT v_id_socio AS id_socio;
END$$

-- Cobro de cuota (se abona POR ADELANTADO, efectivo o tarjeta 3/6 cuotas).
-- Regla del enunciado: "el nuevo plazo comienza a correr desde el día siguiente al vencimiento".
--   * Primer pago del socio          -> el plazo comienza hoy.
--   * Ya tiene un vencimiento previo -> el plazo comienza el día siguiente a ese vencimiento
--                                       (aunque el pago sea en término o con atraso).
-- Si con atraso el nuevo vencimiento sigue siendo anterior a hoy, el socio continúa vencido y debe
-- abonar las cuotas adeudadas (la aplicación lo informa).
CREATE PROCEDURE sp_CobrarCuota(
    IN p_idsocio        INT,
    IN p_monto          DECIMAL(10,2),
    IN p_formapago      VARCHAR(20),
    IN p_cuotastarjeta  INT
)
BEGIN
    DECLARE v_ultimo_venc DATE;
    DECLARE v_inicio      DATE;
    DECLARE v_nuevo_venc  DATE;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    SELECT MAX(fecha_vencimiento) INTO v_ultimo_venc
    FROM cuota
    WHERE id_socio = p_idsocio AND fecha_pago IS NOT NULL;

    IF v_ultimo_venc IS NULL THEN
        SET v_inicio = CURDATE();
    ELSE
        SET v_inicio = DATE_ADD(v_ultimo_venc, INTERVAL 1 DAY);
    END IF;

    SET v_nuevo_venc = DATE_ADD(v_inicio, INTERVAL 1 MONTH);

    INSERT INTO cuota (id_socio, mes, anio, monto, fecha_vencimiento, fecha_pago, forma_pago, cuotas_tarjeta)
    VALUES (p_idsocio, MONTH(v_inicio), YEAR(v_inicio), p_monto, v_nuevo_venc, CURDATE(), p_formapago, p_cuotastarjeta);

    UPDATE socio SET estado = 'Activo' WHERE id_socio = p_idsocio;

    COMMIT;

    SELECT v_nuevo_venc AS nueva_fecha_vencimiento;
END$$

-- Listado diario de socios cuya cuota vigente vence en la fecha indicada
CREATE PROCEDURE sp_ListarVencimientosDia(IN p_fecha DATE)
BEGIN
    SELECT s.id_socio, p.apellido, p.nombre, s.nro_socio, c.fecha_vencimiento, c.mes, c.anio
    FROM socio s
    JOIN persona p ON p.id_persona = s.id_persona
    JOIN cuota c   ON c.id_socio = s.id_socio
    WHERE c.fecha_vencimiento = p_fecha
      AND c.fecha_pago IS NOT NULL
      AND c.fecha_vencimiento = (SELECT MAX(c2.fecha_vencimiento) FROM cuota c2
                                 WHERE c2.id_socio = s.id_socio AND c2.fecha_pago IS NOT NULL)
    ORDER BY p.apellido, p.nombre;
END$$

-- Liquidación de sueldo mensual
CREATE PROCEDURE sp_LiquidarSueldo(
    IN p_idprofesor  INT,
    IN p_mes         INT,
    IN p_anio        INT,
    IN p_monto       DECIMAL(10,2)
)
BEGIN
    INSERT INTO sueldo (id_profesor, mes, anio, monto, fecha_pago)
    VALUES (p_idprofesor, p_mes, p_anio, p_monto, CURDATE())
    ON DUPLICATE KEY UPDATE monto = p_monto, fecha_pago = CURDATE();
END$$

DELIMITER ;

-- =====================================================================
-- DATOS DE PRUEBA
-- =====================================================================
INSERT INTO persona (nombre, apellido, dni, fecha_nacimiento, telefono, direccion, email) VALUES
('Juan',    'Pérez',      '30111222', '1990-05-12', '3624111222', 'San Martín 123',  'juan.perez@mail.com'),
('María',   'Gómez',      '32555666', '1993-08-20', '3624555666', 'Belgrano 456',    'maria.gomez@mail.com'),
('Carlos',  'López',      '28999888', '1985-01-15', '3624999888', 'Sarmiento 789',   'carlos.lopez@mail.com'),
('Lucía',   'Fernández',  '35222111', '1996-11-02', '3624222111', 'Rivadavia 234',   'lucia.fernandez@mail.com'),
('Diego',   'Martínez',   '27444333', '1982-03-30', '3624444333', 'Alberdi 654',     'diego.martinez@mail.com'),
('Ana',     'Ruiz',       '31777999', '1991-07-08', '3624777999', 'Moreno 321',      'ana.ruiz@mail.com'),
('Roberto', 'Sosa',       '25888777', '1978-09-25', '3624888777', 'Mitre 987',       'roberto.sosa@mail.com'),
('Valeria', 'Acosta',     '33666555', '1994-02-14', '3624666555', 'Necochea 159',    'valeria.acosta@mail.com');

-- Socios (persona 1 a 4)
INSERT INTO socio (id_persona, nro_socio, fecha_alta, apto_fisico, estado, carnet_entregado) VALUES
(1, 'S-0001', '2026-01-10', 1, 'Activo', 1),
(2, 'S-0002', '2026-02-05', 1, 'Activo', 1),
(3, 'S-0003', '2025-11-20', 1, 'Inactivo', 0),
(4, 'S-0004', '2026-06-01', 0, 'Activo', 0);

-- Profesores (persona 5 y 6: titular y suplente)
INSERT INTO profesor (id_persona, legajo, especialidad, tipo, horarios_asignados) VALUES
(5, 'P-100', 'Musculación y Aparatos', 'Titular',  'Lun a Vie 08:00-14:00'),
(6, 'P-101', 'Funcional',              'Suplente', 'Sáb 09:00-13:00');

-- No socios (persona 7 y 8)
INSERT INTO no_socio (id_persona) VALUES (7), (8);

-- Actividades
INSERT INTO actividad (nombre, tipo, costo_no_socio, horario, cupo_maximo, id_profesor) VALUES
('Musculación',      'Sala de máquinas', 3500.00, 'Lun a Sáb 08:00-22:00', 40, 1),
('Funcional',         'Clase grupal',     2800.00, 'Lun/Mié/Vie 18:00-19:00', 20, 1),
('Zumba',             'Clase grupal',     2500.00, 'Mar/Jue 19:00-20:00', 25, 2),
('Natación adultos',  'Pileta',           4000.00, 'Lun a Vie 07:00-09:00', 15, NULL);

-- Cuotas (histórico + estado actual)
INSERT INTO cuota (id_socio, mes, anio, monto, fecha_vencimiento, fecha_pago, forma_pago, cuotas_tarjeta) VALUES
(1, 9, 2026, 15000.00, '2026-10-15', '2026-09-14', 'Efectivo', NULL),
(2, 9, 2026, 15000.00, '2026-10-02', '2026-09-01', 'Tarjeta',  3),
(3, 8, 2026, 15000.00, '2026-09-20', '2026-08-20', 'Efectivo', NULL),
(4, 9, 2026, 15000.00, '2026-10-05', '2026-09-25', 'Tarjeta',  6);

-- Carnets
INSERT INTO carnet (id_socio, fecha_emision, fecha_vencimiento) VALUES
(1, '2026-01-10', '2027-01-10'),
(2, '2026-02-05', '2027-02-05');

-- Rutinas
INSERT INTO rutina (id_profesor, id_socio, descripcion, fecha) VALUES
(1, 1, 'Rutina de fuerza tren superior - 4 series x 12 rep. Press banca, remo, dominadas asistidas.', '2026-09-15'),
(1, 2, 'Rutina full body principiante - circuito de 5 estaciones, 3 vueltas.', '2026-09-10');

-- Asistencia de profesores
INSERT INTO asistencia_profesor (id_profesor, fecha, hora_entrada) VALUES
(1, '2026-09-26', '07:55:00'),
(2, '2026-09-26', '08:58:00');

-- Sueldos liquidados
INSERT INTO sueldo (id_profesor, mes, anio, monto, fecha_pago) VALUES
(1, 8, 2026, 450000.00, '2026-08-31'),
(2, 8, 2026, 180000.00, '2026-08-31');

-- Consultas de nutrición (atención los miércoles)
INSERT INTO consulta_nutricion (id_socio, fecha, hora, turno, observaciones, carga_actividad_permitida) VALUES
(1, '2026-09-30', '10:00:00', 1, 'Primer control. Sin patologías previas.', 'Actividad moderada, 3 veces por semana'),
(2, '2026-09-30', '10:30:00', 2, 'Seguimiento nutricional.', 'Actividad intensa, 5 veces por semana');

-- Usuarios del sistema (uno por rol). Contraseña hasheada con SHA-256.
-- Usuario / Contraseña de prueba:  admin/admin123  recepcion/recep123  profesor1/prof123  nutricionista1/nutri123
INSERT INTO usuario (nombre_usuario, contrasena_hash, rol, id_persona, activo) VALUES
('admin',          '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Administrador',  NULL, 1),
('recepcion',      '5d37ed314cf2b5c8462b52b12cd512e2ac4a180e75598da4f12bfb0dea6d0a67', 'Recepcionista',  NULL, 1),
('profesor1',      '00624b02e1f9b996a3278f559d5d55313552ad2c0bafc82adfd975c12df61eaf', 'Profesor',       5,    1),
('nutricionista1', '3b2d163787852a9e127b321a5c8160e8c20f066bcb1485d25e2bca3a1992d5c3', 'Nutricionista',  NULL, 1);
