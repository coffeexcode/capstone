import React from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import Schedule from '../components/screens/Schedule';
import Profile from '../components/screens/Profile';
import PresentQR from '../components/screens/PresentQR';
import ScanQR from '../components/screens/ScanQR';

import { Feather } from '@expo/vector-icons';
import { AntDesign } from '@expo/vector-icons';
import { Ionicons } from '@expo/vector-icons';

const Tab = createBottomTabNavigator();

const createScheduleIcon = ({ color, focused }) => (<AntDesign name="calendar" size={24} color={focused ? color : "black"} />);
const createProfileIcon = ({ color, focused }) => (<Feather name="user" size={24} color={focused ? color : "black"} />);
const createPresentQRIcon = ({ color, focused }) => (<Ionicons name="qr-code-outline" size={24} color={focused ? color : "black"} />);
const createScanQRIcon = ({ color, focused }) => (<AntDesign name="scan1" size={24} color={focused ? color : "black"} />);

const createTab = (title, component, iconFn) => (
  <Tab.Screen 
    name={title}
    component={component}
    options={{ title: title, tabBarIcon: iconFn }}
  />
);

const AttendeeHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', Schedule, createScheduleIcon)}
    {createTab('QR Code', PresentQR, createPresentQRIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

const OrganizerHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', Schedule, createScheduleIcon)}
    {createTab('Scan', ScanQR, createScanQRIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

export {
  AttendeeHome,
  OrganizerHome
}
