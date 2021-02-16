import { Component,OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnectionBuilder } from '@aspnet/signalr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private hubConnection: signalR.HubConnection;
  title = 'SignalRUI';
  ngOnInit() {
    
  }
  public signalConnection():void{
    var connection = this.hubConnection = new HubConnectionBuilder()
    .withUrl("http://localhost:5000/notification", {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    //.withAutomaticReconnect([0, 3000, 5000, 10000, 15000, 30000])
    .configureLogging(signalR.LogLevel.Information)
    .build();
  this.hubConnection.serverTimeoutInMilliseconds = 1800 * 1000; //30 minutes
  this.hubConnection
      .start()
      .then(() => {
        // this.sendUserInfo();
        // if (this.permissions.roleName == HomeConst.defaultValues.superAdmin) {
        //   this.startAlertsHub();
        // }
        console.log('user connected to signalR Hub..!');
        this.sendMessage();
        this.receiveMessage();
      })
      .catch(err => {
        setTimeout(function () { this.createConnection(), this.startConnection(); }, 5000);
      });
  // connection.onreconnected(() => {
  //   this.sendUserInfo();
  // });
  }
  public sendMessage() {
    this.hubConnection.invoke('SendMessage', 'Eswar', 'Hello world');
  }
  public receiveMessage() {
    this.hubConnection.on('ReceiveMessage', (data) => {
     console.log(data);
  })
}
}
