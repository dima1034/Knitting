import React from 'react';
import logo from './logo.svg';
import './App.css';
import NewOrderComponent from './components/layouts/new-order/new-order.component';

const App = () => {
    return (
        <div id="container">
            {/* <header className="App-header"> */}
            {/* <img src={logo} className="App-logo" alt="logo" /> */}
            {/* <a className="App-link" href="https://reactjs.org" target="_blank" rel="noopener noreferrer">
                    Learn React
                </a> */}
            {/* </header> */}
            <main id="main">
                <NewOrderComponent></NewOrderComponent>
            </main>
        </div>
    );
};

export default App;
