DROP SCHEMA IF EXISTS BiblioTec;
CREATE SCHEMA BiblioTec;
USE BiblioTec;

DROP TABLE IF EXISTS categoria;
CREATE TABLE  categoria 
(
  cd_categoria INT,
  nm_categoria VARCHAR(200),
  
  CONSTRAINT pk_categoria PRIMARY KEY (cd_categoria)
);

DROP TABLE IF EXISTS editora;
CREATE TABLE  editora 
(
  cd_editora INT,
  nm_editora VARCHAR(200),
  
  CONSTRAINT pk_editora PRIMARY KEY (cd_editora)
);

DROP TABLE IF EXISTS autor;
CREATE TABLE  autor 
(
  cd_autor INT,
  nm_autor VARCHAR(200),
  
  CONSTRAINT pk_autor PRIMARY KEY (cd_autor)
);

DROP TABLE IF EXISTS livro;
CREATE TABLE  livro 
(
  cd_livro INT,
  cd_ISBN BIGINT,
  nm_livro VARCHAR(200),
  aa_lancamento INT, 
  ds_livro TEXT,
  img_livro BLOB,
  cd_editora INT,
  
  CONSTRAINT pk_livro PRIMARY KEY (cd_livro),
  CONSTRAINT fk_livro_editora FOREIGN KEY (cd_editora)
	REFERENCES editora (cd_editora)
);

DROP TABLE IF EXISTS categoriaLivro;
CREATE TABLE  categoriaLivro 
(
  cd_categoria INT,
  cd_livro INT,  
  
  CONSTRAINT pk_categoriaLivro PRIMARY KEY (cd_categoria, cd_livro),
   CONSTRAINT fk_categoriaLivro_categoria FOREIGN KEY (cd_categoria)
	REFERENCES categoria (cd_categoria) ,
  CONSTRAINT fk_categoriaLivro_livro FOREIGN KEY (cd_livro)
	REFERENCES livro (cd_livro)    
);

DROP TABLE IF EXISTS livroAutor;
CREATE TABLE  livroAutor 
(
  cd_livro INT,
  cd_autor INT,
  
  CONSTRAINT pk_livroAutor PRIMARY KEY (cd_livro, cd_autor),
  CONSTRAINT fk_livroAutor_livro FOREIGN KEY (cd_livro)
	REFERENCES livro (cd_livro),
  CONSTRAINT fk_livroAutor_autor FOREIGN KEY (cd_autor)
	REFERENCES autor (cd_autor)    
);

DROP TABLE IF EXISTS tipoUsuario;
CREATE TABLE  tipoUsuario 
(
  cd_tipoUsuario INT,
  nm_tipoUsuario VARCHAR(200),
  
  CONSTRAINT pk_tipoUsuario PRIMARY KEY (cd_tipoUsuario)
);

DROP TABLE IF EXISTS tipoOcorrencia;
CREATE TABLE  tipoOcorrencia 
(
  cd_tipoOcorrencia INT,
  nm_tipoOcorrencia VARCHAR(200),
  
  CONSTRAINT pk_tipoOcorrencia PRIMARY KEY (cd_tipoOcorrencia)
);

DROP TABLE IF EXISTS usuario;
CREATE TABLE  usuario 
(
  nm_login VARCHAR(200), 
  nm_senha VARCHAR(200),
  nm_usuario VARCHAR(200),
  ic_bloqueado BOOL, 
  dt_bloqueio DATE,
  cd_tipoUsuario INT,
  
  CONSTRAINT pk_usuario PRIMARY KEY (nm_login),
  CONSTRAINT fk_usuario_tipoUsuario FOREIGN KEY (cd_tipoUsuario)
	REFERENCES tipoUsuario (cd_tipoUsuario)
);

DROP TABLE IF EXISTS exemplar;
CREATE TABLE  exemplar 
(
  cd_exemplar INT,
  cd_livro INT,
  
  CONSTRAINT pk_exemplar PRIMARY KEY (cd_exemplar, cd_livro),
  CONSTRAINT fk_exemplar_livro FOREIGN KEY (cd_livro)
	REFERENCES livro (cd_livro)
);

DROP TABLE IF EXISTS emprestimo;
CREATE TABLE  emprestimo 
(
  cd_emprestimo INT,
  nm_login VARCHAR(200),
  cd_exemplar INT,
  cd_livro INT,
  dt_emprestimo DATE,
  dt_devolucaoEstimada DATE,
  dt_devolucao DATE,  
  
  CONSTRAINT pk_emprestimo PRIMARY KEY (cd_emprestimo, nm_login, cd_exemplar, cd_livro),
  CONSTRAINT fk_emprestimo_usuario FOREIGN KEY (nm_login)
	REFERENCES usuario (nm_login),
  CONSTRAINT fk_emprestimo_exemplar FOREIGN KEY (cd_exemplar, cd_livro)
	REFERENCES exemplar (cd_exemplar, cd_livro)
);

DROP TABLE IF EXISTS ocorrencia;
CREATE TABLE  ocorrencia 
(
  cd_ocorrencia INT,
  cd_emprestimo INT,
  cd_exemplar INT,
  cd_livro INT,
  nm_login VARCHAR(200),
  dt_ocorrencia DATE,
  ds_ocorrencia TEXT,
  cd_tipoOcorrencia INT,
  
  CONSTRAINT pk_ocorrencia PRIMARY KEY (cd_ocorrencia, cd_emprestimo, nm_login, cd_exemplar, cd_livro),
  CONSTRAINT fk_ocorrencia_emprestimo FOREIGN KEY (cd_emprestimo, nm_login, cd_exemplar, cd_livro)
	REFERENCES emprestimo (cd_emprestimo, nm_login, cd_exemplar, cd_livro)
);

INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(1, 'Literatura');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(2, 'Biografia');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(3, 'Filosofia');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(4, 'Matemática');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(5, 'Ficção');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(6, 'Aventura');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(7, 'Romance');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(8, 'Mitologia');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(9, 'Suspense');
INSERT INTO categoria (cd_categoria, nm_categoria) VALUES(10, 'Terror');

INSERT INTO editora (cd_editora, nm_editora) VALUES(1, 'Editora FTD');
INSERT INTO editora (cd_editora, nm_editora) VALUES(2, 'Editora Suma');
INSERT INTO editora (cd_editora, nm_editora) VALUES(3, 'Editora HarperCollins');
INSERT INTO editora (cd_editora, nm_editora) VALUES(4, 'Editora Aleph');
INSERT INTO editora (cd_editora, nm_editora) VALUES(5, 'Grupo Editorial Record');
INSERT INTO editora (cd_editora, nm_editora) VALUES(6, 'Livraria Garnier');
INSERT INTO editora (cd_editora, nm_editora) VALUES(7, 'Tipografia Nacional');
INSERT INTO editora (cd_editora, nm_editora) VALUES(8, 'Melhoramentos');
INSERT INTO editora (cd_editora, nm_editora) VALUES(9, 'Alfaguara');
INSERT INTO editora (cd_editora, nm_editora) VALUES(10, 'Intrínseca');
INSERT INTO editora (cd_editora, nm_editora) VALUES(11, 'Companhia das Letras');
INSERT INTO editora (cd_editora, nm_editora) VALUES(12, 'Principis');

INSERT INTO autor (cd_autor, nm_autor) VALUES(1, 'Regina Giovanni');
INSERT INTO autor (cd_autor, nm_autor) VALUES(2, 'Jose Ruy Bonjorno');
INSERT INTO autor (cd_autor, nm_autor) VALUES(3, 'Neil Gaiman');
INSERT INTO autor (cd_autor, nm_autor) VALUES(4, 'J. R. R. Token');
INSERT INTO autor (cd_autor, nm_autor) VALUES(5, 'Machado de Assis');
INSERT INTO autor (cd_autor, nm_autor) VALUES(6, 'Anne Frank');
INSERT INTO autor (cd_autor, nm_autor) VALUES(7, 'Antoine de Saint-Exupéry');
INSERT INTO autor (cd_autor, nm_autor) VALUES(8, 'Mario Vargas Llosa');
INSERT INTO autor (cd_autor, nm_autor) VALUES(9, 'John Green');
INSERT INTO autor (cd_autor, nm_autor) VALUES(10, 'George Orwell');

INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(1, 8532223796, 'Matematica - V. 3 - Geometria Analitica, Numeros Complexos E Polinomio', 2021, NULL, 1);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(2, 3498875612, 'Mitologia Nórdica', 2017, 'Quem, além de Neil Gaiman, poderia se tornar cúmplice dos deuses e usar de sua habilidade com as palavras para recontar as histórias dos mitos nórdicos? Fãs e leitores sabem que a mitologia nórdica sempre teve grande influência na obra do autor. Depois de servirem de inspiração para clássicos como Deuses americanos e Sandman, Gaiman agora investiga o universo dos mitos nórdicos. Em Mitologia nórdica, ele vai até a fonte dos mitos para criar sua própria versão, com o inconfundível estilo sagaz e inteligente que permeia toda a sua obra.', 2);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(3, 9788595084759, 'O Senhor dos Aneis e a Sociedade do Anel', 1939, 'O ANEL DO PODER!', 3);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(4, 9788567097091, 'Dom Casmurro', 1899, '"Dom Casmurro", de Machado de Assis, teve sua primeira edição lançada em 1900. O livro pode ser compreendido como a autopsicanálise de Bento Santiago, que viveu uma história de amor com final trágico', 6);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(5, 9780141032009, 'Diário de Anne Frank', 1947, 'O Diário de Anne Frank é um livro escrito por Anne Frank entre 12 de junho de 1942 e 1.º de agosto de 1944 durante a Segunda Guerra Mundial. É conhecido por narrar momentos vivenciados pelo grupo de judeus confinados em um esconderijo durante a ocupação nazista dos Países Baixos.', 3);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(6, 9780850515022, 'Memórias Póstumas de Brás Cubas', 1881, 'Memórias Póstumas é uma narrativa confusa e sem linearidade. O personagem principal, como sugere o título, resolve, depois de morto, contar a história da sua vida através de uma seleção dos episódios mais relevantes, desde o seu nascimento até a sua morte.', 7);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(7, 9788506073254, 'O Pequeno Príncipe', 1943, 'O Pequeno Príncipe – Um piloto cai com seu avião no deserto e ali encontra uma criança loura e frágil. Ela diz ter vindo de um pequeno planeta distante. E ali, na convivência com o piloto perdido, os dois repensam os seus valores e encontram o sentido da vida.', 8);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(8, 9788573028089, 'Travessuras da menina má', 2006, 'Travessuras da menina má é uma obra de ficção, levemente autobiográfica, do escritor peruano Mario Vargas Llosa, Prêmio Nobel de Literatura de 2010. O livro, publicado em 2006, narra uma história de amor repleta de referências a acontecimentos que marcaram o mundo durante a segunda metade do século XX.', 9);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(9, 9788580572261, 'A Culpa é Das Estrelas', 2012, '"A culpa é das estrelas" narra o romance de dois adolescentes que se conhecem (e se apaixonam) em um Grupo de Apoio para Crianças com Câncer: Hazel, uma jovem de dezesseis anos que sobrevive graças a uma droga revolucionária que detém a metástase em seus pulmões, e Augustus Waters, de dezessete, ex-jogador de basquete.', 10);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(10, 9788535914849, '1984', 1949, 'O romance descreve a existência sufocante dos indivíduos que vivem num sistema de opressão e autoritarismo. Para poder controlar os cidadãos, o governo precisa padronizar as suas vidas e os seus comportamentos.', 11);
INSERT INTO livro (cd_livro, cd_ISBN, nm_livro, aa_lancamento, ds_livro, cd_editora) VALUES(11, 9786555521856, 'A revolução dos bichos', 1945, 'O livro relata que os animais que viviam na Fazenda dos Bichos se sentiram mal tratados pelo seu cuidador, Sr Jones, com uma péssima qualidade de vida, chegando em determinado momento a faltar comida para todos e, depois de várias deliberações, resolveram agir para expulsar os humanos e assumir o controle da fazenda.', 12);

-- Livro 1
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(1, 4);

-- Livro 2
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(2, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(2, 3);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(2, 8);

-- Livro 3
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(3, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(3, 5);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(3, 8);

-- Livro 4
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(4, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(4, 7);

-- Livro 5
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(5, 2);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(5, 6);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(5, 7);

-- Livro 6
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(6, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(6, 7);

-- Livro 7
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(7, 5);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(7, 6);

-- Livro 8
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(8, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(8, 5);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(8, 6);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(8, 7);

-- Livro 9
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(9, 2);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(9, 5);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(9, 7);

-- Livro 10
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(10, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(10, 5);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(10, 6);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(10, 9);

-- Livro 11
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(11, 1);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(11, 3);
INSERT INTO categoriaLivro (cd_livro, cd_categoria) VALUES(11, 5);

-- Livro 1
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(1, 1);
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(1, 2);

-- Livro 2
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(2, 3);

-- Livro 3
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(3, 4);

-- Livro 4
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(4, 5);

-- Livro 5
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(5, 6);

-- Livro 6
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(6, 5);

-- Livro 7
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(7, 7);

-- Livro 8
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(8, 8);

-- Livro 9
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(9, 9);

-- Livro 10
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(10, 10);

-- Livro 11
INSERT INTO livroAutor (cd_livro, cd_autor) VALUES(11, 10);

INSERT INTO tipoUsuario (cd_tipoUsuario, nm_tipoUsuario) VALUES(1, 'Usuário');
INSERT INTO tipoUsuario (cd_tipoUsuario, nm_tipoUsuario) VALUES(2, 'Cliente');

INSERT INTO tipoOcorrencia (cd_tipoOcorrencia, nm_tipoOcorrencia) VALUES(1, 'Devolução com leve dano');
INSERT INTO tipoOcorrencia (cd_tipoOcorrencia, nm_tipoOcorrencia) VALUES(2, 'Devolução com dano moderado');
INSERT INTO tipoOcorrencia (cd_tipoOcorrencia, nm_tipoOcorrencia) VALUES(3, 'Devolução com grave dano');
INSERT INTO tipoOcorrencia (cd_tipoOcorrencia, nm_tipoOcorrencia) VALUES(4, 'Atraso na devolução');

INSERT INTO usuario (nm_login, nm_senha, nm_usuario, ic_bloqueado, dt_bloqueio, cd_tipoUsuario) VALUES('User1', 'User1', 'Usuário1', 0, NULL, 1);
INSERT INTO usuario (nm_login, nm_senha, nm_usuario, ic_bloqueado, dt_bloqueio, cd_tipoUsuario) VALUES('36400', '36400', 'Luiz Moraes', 0, NULL, 2);
INSERT INTO usuario (nm_login, nm_senha, nm_usuario, ic_bloqueado, dt_bloqueio, cd_tipoUsuario) VALUES('36403', '36403', 'Isadora Assumpção', 1, '2023-10-09', 2);
INSERT INTO usuario (nm_login, nm_senha, nm_usuario, ic_bloqueado, dt_bloqueio, cd_tipoUsuario) VALUES('36405', '36405', 'Raphael Resende', 1, '2023-10-01', 2);

-- Livro 1
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 1);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 1);

-- Livro 2
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(3, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(4, 2);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(5, 2);

-- Livro 3
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 3);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(3, 3);

-- Livro 4
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 4);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 4);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(3, 4);

-- Livro 5
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 5);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 5);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(3, 5);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(4, 5);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(5, 5);

-- Livro 6
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 6);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 6);

-- Livro 7
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 7);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 7);

-- Livro 8
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 8);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 8);

-- Livro 9
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 9);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 9);

-- Livro 10
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 10);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 10);

-- Livro 11
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(1, 11);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(2, 11);
INSERT INTO exemplar (cd_exemplar, cd_livro) VALUES(3, 11);

INSERT INTO emprestimo(cd_emprestimo, nm_login, cd_exemplar, cd_livro, dt_emprestimo, dt_devolucao, dt_devolucaoEstimada) VALUES(1, '36400', 1, 1, CURRENT_DATE, NULL, '2023-10-24');