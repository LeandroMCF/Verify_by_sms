import { Component } from 'react';
import axios from 'axios';
import './App.css';

class App extends Component{
  constructor(props){
    super(props);
    this.state = {
      numero: '',
    }
  }

  enviar = () => {
    axios.post('https://localhost:5001/api/Mensagem/Enviar', {

      cel : this.state.numero

    })
    .then(resposta => {
      localStorage.setItem('codigo', resposta.data);
    })
  }

  render(){
    return (
      <div className="App">
        <div className='body'>
          <h1>Teste</h1>
          {/* <form onSubmit={this.enviar}> */}
            <input></input>
            <button type='submit'>Entrar</button>
        </div>
      </div>
    );
  }
}

export default App;