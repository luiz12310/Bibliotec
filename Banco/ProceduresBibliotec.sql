DELIMITER $$

DROP PROCEDURE IF EXISTS AcessarSistema$$
CREATE PROCEDURE AcessarSistema(vLogin VARCHAR(200), vSenha VARCHAR(200))
BEGIN
	SELECT u.nm_login FROM usuario u WHERE u.nm_login = vLogin AND u.nm_senha = vSenha;
END$$

DROP PROCEDURE IF EXISTS AcessarSistemaComputador$$
CREATE PROCEDURE AcessarSistemaComputador(vLogin VARCHAR(200), vSenha VARCHAR(200))
BEGIN
	SELECT u.nm_login FROM usuario u WHERE u.nm_login = vLogin AND u.nm_senha = vSenha;
END$$

DROP PROCEDURE IF EXISTS BuscarUsuario$$
CREATE PROCEDURE BuscarUsuario(vPesquisa VARCHAR(200))
BEGIN
	SELECT u.nm_login FROM usuario u
    WHERE u.cd_tipoUsuario <> 1 AND u.nm_usuario LIKE CONCAT('%', vPesquisa, '%')
    OR u.cd_tipoUsuario <> 1 AND u.nm_login LIKE CONCAT('%', vPesquisa, '%')
    ORDER BY u.nm_usuario;
END$$

DROP PROCEDURE IF EXISTS ContarQuantidadeEmprestimos$$
CREATE PROCEDURE ContarQuantidadeEmprestimos(vLogin VARCHAR(200))
BEGIN
	SELECT * FROM emprestimo WHERE nm_login = vLogin AND dt_devolucao IS NULL;
END$$

DROP PROCEDURE IF EXISTS DetalharLivro$$
CREATE PROCEDURE DetalharLivro(vCodigoLivro INT)
BEGIN
	DECLARE qtDisponiveis INT DEFAULT 0;
    DECLARE qtTotal INT DEFAULT 0;
    DECLARE livrosEmprestados INT DEFAULT 0;
    
    SELECT COUNT(em.cd_exemplar) INTO livrosEmprestados FROM emprestimo em WHERE em.cd_livro = vCodigoLivro AND em.dt_devolucao IS NULL;
    
    SELECT COUNT(e.cd_exemplar) INTO qtTotal FROM exemplar e
    WHERE e.cd_livro = vCodigoLivro;
    
    SET qtDisponiveis = qtTotal - livrosEmprestados;
    
    SELECT l.nm_livro, l.cd_isbn, e.cd_editora, l.aa_lancamento, qtDisponiveis, qtTotal, GROUP_CONCAT(DISTINCT(c.cd_categoria)), 
    GROUP_CONCAT(DISTINCT(a.cd_autor)), l.ds_livro FROM livro l
    JOIN editora e ON(l.cd_editora = e.cd_editora) 
    JOIN categoriaLivro cl ON(l.cd_livro = cl.cd_livro) 
    JOIN categoria c ON(cl.cd_categoria = c.cd_categoria)
	JOIN livroAutor la ON(la.cd_livro = l.cd_livro) 
	JOIN autor a ON(a.cd_autor = la.cd_autor) 
    WHERE l.cd_livro = vCodigoLivro GROUP BY l.cd_livro;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosLivro$$
CREATE PROCEDURE PreencherDadosLivro(vCodigoLivro INT)
BEGIN
	SELECT l.nm_livro, l.cd_isbn, l.aa_lancamento, l.ds_livro, l.cd_editora, GROUP_CONCAT(DISTINCT(cl.cd_categoria)), GROUP_CONCAT(DISTINCT(la.cd_autor)) FROM livro l
	JOIN categoriaLivro cl ON(cl.cd_livro = l.cd_livro)
	JOIN livroAutor la ON(la.cd_livro = l.cd_livro)
	WHERE l.cd_livro = vCodigoLivro GROUP BY l.cd_livro;
END$$

DROP PROCEDURE IF EXISTS DevolverLivro$$
CREATE PROCEDURE DevolverLivro(vLogin VARCHAR(200), vCodigoLivro INT, vCodigoExemplar INT, vCodigoEmprestimo INT)
BEGIN
	UPDATE emprestimo em SET em.dt_devolucao = CURRENT_DATE WHERE em.nm_login = vLogin AND em.cd_livro = vCodigoLivro AND em.cd_exemplar = vCodigoExemplar AND em.cd_emprestimo = vCodigoEmprestimo;
END$$

DROP PROCEDURE IF EXISTS EnviarOcorrencia$$
CREATE PROCEDURE EnviarOcorrencia(vLogin VARCHAR(200), vDescricao TEXT, vNomeTipoOcorrencia VARCHAR(200), vCodigoExemplar INT, vCodigoLivro INT, vCodigoEmprestimo INT)
BEGIN
	DECLARE qt_ocorrencias INT DEFAULT 0;
	DECLARE codigoTipoOcorrencia INT DEFAULT 0;

	SELECT MAX(cd_ocorrencia) INTO qt_ocorrencias FROM ocorrencia;
    IF qt_ocorrencias IS NULL THEN
		SET qt_ocorrencias = 0;
	END IF;
    SELECT tr.cd_tipoOcorrencia INTO codigoTipoOcorrencia FROM tipoOcorrencia tr WHERE tr.nm_tipoOcorrencia = vNomeTipoOcorrencia;
    
    SET qt_ocorrencias = qt_ocorrencias + 1;
    UPDATE usuario u SET u.ic_bloqueado = TRUE, u.dt_bloqueio = CURRENT_DATE WHERE u.nm_login = vLogin;
	INSERT INTO ocorrencia(cd_ocorrencia, cd_emprestimo, cd_exemplar, cd_livro, nm_login, dt_ocorrencia, ds_ocorrencia, cd_tipoOcorrencia) VALUES(qt_ocorrencias, vCodigoEmprestimo, vCodigoExemplar, vCodigoLivro, vLogin, CURRENT_DATE, vDescricao, codigoTipoOcorrencia);    
END$$

DROP PROCEDURE IF EXISTS ListarDisponibilidade$$
CREATE PROCEDURE ListarDisponibilidade(vCodigoLivro INT)
BEGIN
	DECLARE qtDisponiveis INT DEFAULT 0;
    DECLARE qtTotal INT DEFAULT 0;
    DECLARE livrosEmprestados INT DEFAULT 0;
    
    SELECT COUNT(em.cd_exemplar) INTO livrosEmprestados FROM emprestimo em WHERE em.cd_livro = vCodigoLivro AND em.dt_devolucao IS NULL;
    
    SELECT COUNT(e.cd_exemplar) INTO qtTotal FROM exemplar e
    WHERE e.cd_livro = vCodigoLivro;
    
    SET qtDisponiveis = qtTotal - livrosEmprestados;
    
    SELECT qtDisponiveis, qtTotal;
END$$

DROP PROCEDURE IF EXISTS PreencherEmprestimo$$
CREATE PROCEDURE PreencherEmprestimo(vLogin VARCHAR(200), vCodigoLivro INT, vCodigoExemplar INT, vCodigoEmprestimo INT)
BEGIN
	SELECT dt_emprestimo, dt_devolucaoEstimada,
    CASE WHEN dt_devolucao IS NULL THEN '1000-10-10'
    WHEN dt_devolucao IS NOT NULL THEN dt_devolucao 
    END FROM emprestimo 
    WHERE nm_login = vLogin AND cd_livro = vCodigoLivro AND cd_exemplar = vCodigoExemplar AND cd_emprestimo = vCodigoEmprestimo;
END$$

DROP PROCEDURE IF EXISTS ListarEmprestimos$$
CREATE PROCEDURE ListarEmprestimos(vLogin VARCHAR(200))
BEGIN
	SELECT em.cd_emprestimo, em.nm_login, em.cd_exemplar, em.cd_livro, dt_emprestimo, dt_devolucaoEstimada,
    CASE WHEN dt_devolucao IS NULL THEN '1000-10-10'
    WHEN dt_devolucao IS NOT NULL THEN dt_devolucao
    END, em.cd_livro
    FROM emprestimo em 
    WHERE em.nm_login = vLogin AND em.dt_devolucao IS NULL;
END$$

DROP PROCEDURE IF EXISTS ListarTodosLivros$$
CREATE PROCEDURE ListarTodosLivros()
BEGIN
	SELECT l.cd_livro FROM livro l
	GROUP BY l.cd_livro;
END$$

DROP PROCEDURE IF EXISTS ListarUsuarios$$
CREATE PROCEDURE ListarUsuarios()
BEGIN
	SELECT u.nm_login FROM usuario u
    WHERE u.cd_tipoUsuario <> 1
    ORDER BY u.nm_usuario;
END$$

DROP PROCEDURE IF EXISTS EditarUsuario$$
CREATE PROCEDURE EditarUsuario(vLogin VARCHAR(200), vNome VARCHAR(200), vSenha VARCHAR(200))
BEGIN
	UPDATE usuario SET nm_usuario = vNome, nm_senha = vSenha WHERE nm_login = vLogin;
END$$

DROP PROCEDURE IF EXISTS DesbloquearUsuario$$
CREATE PROCEDURE DesbloquearUsuario(vLogin VARCHAR(200))
BEGIN
	UPDATE usuario SET ic_bloqueado = FALSE, dt_bloqueio = NULL WHERE nm_login = vLogin;
END$$

DROP PROCEDURE IF EXISTS ListarUsuariosBloqueados$$
CREATE PROCEDURE ListarUsuariosBloqueados()
BEGIN
	SELECT u.nm_login FROM usuario u
    WHERE u.cd_tipoUsuario <> 1 AND u.ic_bloqueado = 1
    ORDER BY u.nm_usuario;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosEditora$$
CREATE PROCEDURE PreencherDadosEditora(vCodigoEditora INT)
BEGIN
	SELECT e.nm_editora FROM editora e WHERE e.cd_editora = vCodigoEditora;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosCategoria$$
CREATE PROCEDURE PreencherDadosCategoria(vCodigoCategoria INT)
BEGIN
	SELECT c.nm_categoria FROM categoria c WHERE c.cd_categoria = vCodigoCategoria;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosEmprestimo$$
CREATE PROCEDURE PreencherDadosEmprestimo(vLogin VARCHAR(200), vCodigoExemplar INT, vCodigoLivro INT)
BEGIN
	SELECT em.cd_emprestimo, em.dt_emprestimo, em.dt_devolucao, em.dt_devolucaoEstimada FROM emprestimo em WHERE em.nm_login = vLogin AND em.cd_exemplar = vCodigoExemplar AND em.cd_livro = vCodigoLivro;
END$$

DROP PROCEDURE IF EXISTS PreencherOcorrencias$$
CREATE PROCEDURE PreencherOcorrencias()
BEGIN
	SELECT nm_tipoOcorrencia FROM tipoOcorrencia
    ORDER BY nm_tipoOcorrencia;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosTipoUsuario$$
CREATE PROCEDURE PreencherDadosTipoUsuario(vCodigoTipoUser INT)
BEGIN
	SELECT tu.nm_tipoUsuario FROM tipoUsuario tu WHERE tu.cd_tipoUsuario = vCodigoTipoUser;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosUsuario$$
CREATE PROCEDURE PreencherDadosUsuario(vLogin VARCHAR(200))
BEGIN
	DECLARE bloqueado BOOL DEFAULT FALSE;
    DECLARE dataDesbloqueio DATE DEFAULT NULL;
    DECLARE dataBloqueio DATE DEFAULT NULL;
    
	SELECT u.ic_bloqueado INTO bloqueado FROM usuario u WHERE u.nm_login = vLogin;
	SELECT u.dt_bloqueio INTO dataBloqueio FROM usuario u WHERE u.nm_login = vLogin;
    
    IF bloqueado THEN
		SET dataDesbloqueio = ADDDATE(dataBloqueio, INTERVAL 15 DAY);
        
		SELECT u.nm_usuario, u.nm_senha, u.ic_bloqueado, u.cd_tipoUsuario, u.dt_bloqueio, dataDesbloqueio FROM usuario u 
		WHERE u.nm_login = vLogin;
	ELSE
		SELECT u.nm_usuario, u.nm_senha, u.ic_bloqueado, u.cd_tipoUsuario, u.dt_bloqueio, dataDesbloqueio FROM usuario u 
		WHERE u.nm_login = vLogin;
	END IF;
END$$

DROP PROCEDURE IF EXISTS PreencherCategoria$$
CREATE PROCEDURE PreencherCategoria(vCodigo INT)
BEGIN
	SELECT c.nm_categoria FROM categoria c WHERE c.cd_categoria = vCodigo;
END$$

DROP PROCEDURE IF EXISTS PreencherAutor$$
CREATE PROCEDURE PreencherAutor(vCodigo INT)
BEGIN
	SELECT a.nm_autor FROM autor a WHERE a.cd_autor = vCodigo;
END$$

DROP PROCEDURE IF EXISTS ListarEditoras$$
CREATE PROCEDURE ListarEditoras()
BEGIN
	SELECT cd_editora FROM editora;
END$$

DROP PROCEDURE IF EXISTS EditarAutor$$
CREATE PROCEDURE EditarAutor(vCodigo INT, vNome VARCHAR(200))
BEGIN
	UPDATE autor SET nm_autor = vNome WHERE cd_autor = vCodigo;
END$$

DROP PROCEDURE IF EXISTS EditarCategoria$$
CREATE PROCEDURE EditarCategoria(vCodigo INT, vNome VARCHAR(200))
BEGIN
	UPDATE categoria SET nm_categoria = vNome WHERE cd_categoria = vCodigo;
END$$

DROP PROCEDURE IF EXISTS CriarAutor$$
CREATE PROCEDURE CriarAutor(vNome VARCHAR(200))
BEGIN
	DECLARE qtAutor INT DEFAULT 0;    
    SELECT MAX(cd_autor) INTO qtAutor FROM autor;
    SET qtAutor = qtAutor + 1;
    
	INSERT INTO autor(cd_autor, nm_autor) VALUES (qtAutor, vNome);
END$$

DROP PROCEDURE IF EXISTS CriarCategoria$$
CREATE PROCEDURE CriarCategoria(vNome VARCHAR(200))
BEGIN
	DECLARE qtCategoria INT DEFAULT 0;    
    SELECT MAX(cd_categoria) INTO qtCategoria FROM categoria;
    SET qtCategoria = qtCategoria + 1;
    
	INSERT INTO categoria(cd_categoria, nm_categoria) VALUES (qtCategoria, vNome);
END$$

DROP PROCEDURE IF EXISTS CriarEditora$$
CREATE PROCEDURE CriarEditora(vNome VARCHAR(200))
BEGIN
	DECLARE qtEditora INT DEFAULT 0;    
    SELECT MAX(cd_editora) INTO qtEditora FROM editora;
    SET qtEditora = qtEditora + 1;
    
	INSERT INTO editora(cd_editora, nm_editora) VALUES (qtEditora, vNome);
END$$

DROP PROCEDURE IF EXISTS ListarCategorias$$
CREATE PROCEDURE ListarCategorias()
BEGIN
	SELECT cd_categoria FROM categoria;
END$$

DROP PROCEDURE IF EXISTS ListarAutores$$
CREATE PROCEDURE ListarAutores()
BEGIN
	SELECT cd_autor FROM autor;
END$$

DROP PROCEDURE IF EXISTS PesquisarLivro$$
CREATE PROCEDURE PesquisarLivro(vPesquisar VARCHAR(200))
BEGIN
	SELECT l.cd_livro FROM livro l
	JOIN editora e ON(e.cd_editora = l.cd_editora)
	JOIN livroAutor la ON(la.cd_livro = l.cd_livro)
    JOIN autor a ON(a.cd_autor = la.cd_autor)
    WHERE l.nm_livro LIKE CONCAT('%', vPesquisar, '%')
    OR e.nm_editora LIKE CONCAT('%', vPesquisar, '%')
    OR a.nm_autor LIKE CONCAT('%', vPesquisar, '%')
    GROUP BY l.cd_livro;
END$$

DROP PROCEDURE IF EXISTS RealizarEmprestimo$$
CREATE PROCEDURE RealizarEmprestimo(vLogin VARCHAR(200), vCodigoLivro INT)
BEGIN
	DECLARE cdEmprestimo INT DEFAULT 0;
	DECLARE dtEntrega DATE DEFAULT '1000-10-10';
	DECLARE cdExemplar INT DEFAULT 0;
    DECLARE erro CONDITION FOR SQLSTATE '45000';
    
	SELECT MAX(cd_emprestimo) INTO cdEmprestimo FROM emprestimo;
    SET cdEmprestimo = cdEmprestimo + 1;
    
    SELECT ADDDATE(CURRENT_DATE, INTERVAL 16 DAY) INTO dtEntrega;
    
    SELECT e.cd_exemplar INTO cdExemplar FROM exemplar e WHERE e.cd_livro = vCodigoLivro 
	AND e.cd_exemplar NOT IN (SELECT em.cd_exemplar FROM emprestimo em WHERE em.cd_livro = e.cd_livro AND em.dt_devolucao IS NULL) LIMIT 1;
    
    IF cdExemplar <> 0 THEN
		INSERT INTO emprestimo(cd_emprestimo, nm_login, cd_livro, cd_exemplar, dt_emprestimo, dt_devolucao, dt_devolucaoEstimada) VALUES(cdEmprestimo, vLogin, vCodigoLivro, cdExemplar, CURRENT_DATE, NULL, dtEntrega);
	ELSE
		SIGNAL erro
		SET MESSAGE_TEXT = 'Não existe exemplar disponível desse livro';
	END IF;
END$$

DROP PROCEDURE IF EXISTS ListarCategoria$$
CREATE PROCEDURE ListarCategoria()
BEGIN
	SELECT nm_categoria, cd_categoria FROM categoria ORDER BY nm_categoria;
END$$

DROP PROCEDURE IF EXISTS ListarLivros$$
CREATE PROCEDURE ListarLivros(vLogin VARCHAR(200))
BEGIN
	SELECT cd_livro FROM emprestimo WHERE nm_login = vLogin;
END$$

DROP PROCEDURE IF EXISTS ListarLivrosCategorias$$
CREATE PROCEDURE ListarLivrosCategorias(vCategoria INT)
BEGIN
	SELECT l.cd_livro FROM livro l
	JOIN categoriaLivro cl ON(cl.cd_livro = l.cd_livro) 
    WHERE cl.cd_categoria = vCategoria;
END$$

DELIMITER ;