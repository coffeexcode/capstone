import React from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';

import Schedule from '@screens/User/Schedule';
import Profile from '@screens/User/Profile';
import Event from '@screens/User/Event';

import PresentQR from '@screens/Attendee/PresentQR';
import About from '@screens/Attendee/About';
import Sponsors from '@screens/Attendee/Sponsors';
import Contact from '@screens/Attendee/Contact';

import ScanQR from '@screens/Organizer/ScanQR';
import ScanAction from '@screens/Organizer/ScanAction';

import {
  createAboutIcon,
  createScanQRIcon,
  createScheduleIcon,
  createPresentQRIcon,
  createProfileIcon
} from '@utils/iconSelector';

const Tab = createBottomTabNavigator();
const ScheduleStack = createStackNavigator();
const ScanQRStack = createStackNavigator();
const AboutStack = createStackNavigator();


/**
 * Returns the The Schedule Stack Navigator 
 * Supports traversal of pages within a Tab Navigator
 */
const ScheduleStackScreens = () => (
  <ScheduleStack.Navigator initialRouteName="Schedule">
    <ScheduleStack.Screen name="Schedule" component={Schedule} />
    <ScheduleStack.Screen name="Event" component={Event} />
  </ScheduleStack.Navigator>
);

/**
 * Returns the The Scan QR Stack Navigator 
 * Supports traversal of pages within a Tab Navigator
 */
const ScanQRStackScreens = () => (
  <ScanQRStack.Navigator initialRouteName="ScanQR">
    <ScanQRStack.Screen name="ScanQR" component={ScanQR} />
    <ScanQRStack.Screen name="ScanAction" component={ScanAction} />
  </ScanQRStack.Navigator>
);

/**
 * Returns the The About Stack Navigator 
 * Supports traversal of pages within a Tab Navigator
 */
const AboutStackScreens = () => (
  <AboutStack.Navigator initialRouteName="About">
    <AboutStack.Screen name="About" component={About} />
    <AboutStack.Screen name="Sponsors" component={Sponsors} />
    <AboutStack.Screen name="Contact" component={Contact}/>
  </AboutStack.Navigator>
);

/**
 * Returns a created Tab screen
 * @param {string} title of screen to be displayed
 * @param {Component} component of screen to be rendered
 * @param {function} iconFn callback icon function 
 */
const createTab = (title, component, iconFn) => (
  <Tab.Screen 
    name={title}
    component={component}
    options={{ title: title, tabBarIcon: iconFn }}
  />
);

/**
 * Returns the Attendee Home View as a Tab Navigator
 * With 4 tabs: Schedule, Present QR Code, About, Profile
 * 
 */
const AttendeeHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', ScheduleStackScreens, createScheduleIcon)}
    {createTab('QR Code', PresentQR, createPresentQRIcon)}
    {createTab('About', AboutStackScreens, createAboutIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

/**
 * Returns the Organizer/Sponsor Home View as a Tab Navigator
 * With 3 tabs: Schedule, Scan QR Code, About, Profile
 * 
 * Note: Both Organizers and Sponsors have the same tabs, however, they have different functionality within the tabs
 */
const OrganizerHome = () => (
  <Tab.Navigator
    tabBarOptions={{ activeTintColor: '#6C63FF' }}
  >
    {createTab('Schedule', ScheduleStackScreens, createScheduleIcon)}
    {createTab('Scan', ScanQRStackScreens, createScanQRIcon)}
    {createTab('Profile', Profile, createProfileIcon)}
  </Tab.Navigator>
);

export {
  AttendeeHome,
  OrganizerHome
}
