import React from 'react';
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';
import ConsultarProdutos from './components/pages/produto/ConsultarProdutos';
import CadastrarProduto from './components/pages/produto/CadastrarProduto';
import './App.css'

const App: React.FC = () => {
    return (
        <BrowserRouter>
            <div className="App">
                <nav>
                    <ul>
                        <li>
                            <Link to="/">Lista de Produtos</Link>
                        </li>
                        <li>
                            <Link to="/cadastro">Cadastro de Produto</Link>
                        </li>
                    </ul>
                </nav>
                <Routes>
                    <Route path="/" element={<ConsultarProdutos />} />
                    <Route path="/cadastro" element={<CadastrarProduto />} />
                </Routes>
            </div>
        </BrowserRouter>
    );
};

export default App;
