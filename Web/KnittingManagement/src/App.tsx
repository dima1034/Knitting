import React from 'react';
import logo from './logo.svg';
import './App.css';
import NewOrderComponent from './components/layouts/new-order/new-order.component';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import TaskBoardComponent from './components/layouts/task-board/task-board.component';
import CardListComponent from './components/layouts/task-board/components/card-list.component/card-list.component';

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
                <Router>
                    <Switch>
                        <Route path="/new" component={NewOrderComponent} exact></Route>
                        <Route path="/board" component={TaskBoardComponent} exact></Route>
                        <Route path="/card" component={CardListComponent} exact></Route>
                    </Switch>
                </Router>
            </main>
        </div>
    );
};

export default App;
