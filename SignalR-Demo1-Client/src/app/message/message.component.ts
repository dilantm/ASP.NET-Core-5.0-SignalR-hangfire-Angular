import { HttpClient, HttpUrlEncodingCodec } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  //private _hubConnection: HubConnection;
  connection: signalR.HubConnection;
  showimage: boolean=true;
  signaldata: any[]=[];
  tempMessage :string;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    //this._hubConnection = new HubConnectionBuilder().withUrl('https://localhost:44368/notify').build();
    this.connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:15576/notify') // the SignalR server url as set in the .NET Project properties and Startup class
        .build();
    // this._hubConnection.start()
    // .then(()=>
    // console.log('connection start'+this._hubConnection))
    // .catch(err=>{
    //   console.log('Error while establishing the connection')
    // });

      this.connection
        .start()
        .then(() => {
          console.log(`SignalR connection success! connectionId: ${this.connection.connectionId} `);
        })
        .catch((error) => {
          console.log(`SignalR connection error: ${error}`);
          reject();
        });

    this.connection.on('BroadcastMessage', (message)=>{
      this.signaldata.push(message);
      console.log(message);
      this.tempMessage=message.information;
      this.showimage=true;

    })

  }

  showMessage(){
    this.showimage=true;
  }

}
function reject() {
  throw new Error('Function not implemented.');
}

