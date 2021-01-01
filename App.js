import { StatusBar } from 'expo-status-bar';
import React from 'react';
import Landing from './components/screens/Landing';
import SignIn from './components/screens/SignIn';
import SelectView from './components/screens/SelectView';
import Subscriber from './components/screens/Subscriber';
import Sponsor from './components/screens/Sponsor';
import Attendee from './components/screens/Attendee';
import PresentQR from './components/screens/PresentQR';
import ScanQR from './components/screens/ScanQR';


export default function App() {
  return (
    <>
      <PresentQR/>
      <StatusBar style="auto" />
    </>
  );
}
