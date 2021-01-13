import React from 'react';
import { AntDesign, Entypo, FontAwesome, FontAwesome5, Feather, Ionicons, MaterialCommunityIcons } from '@expo/vector-icons'; 

/**
 * Icon callback functions to be created when the bottom tabs are created
 * 
 * @param {string} props.color icon colour to be presented
 * @param {boolean} props.focused whether the current tab is currently in focus
 */
const createAboutIcon = ({ color, focused }) => (<Ionicons name="information-circle-outline" size={24} color={focused ? color : "black"} />);
const createScheduleIcon = ({ color, focused }) => (<AntDesign name="calendar" size={24} color={focused ? color : "black"} />);
const createProfileIcon = ({ color, focused }) => (<Feather name="user" size={24} color={focused ? color : "black"} />);
const createPresentQRIcon = ({ color, focused }) => (<Ionicons name="qr-code-outline" size={24} color={focused ? color : "black"} />);
const createScanQRIcon = ({ color, focused }) => (<AntDesign name="scan1" size={24} color={focused ? color : "black"} />);


/**
 * Returns which icon to represent an event
 * 
 * @param {string} type of event being rendered
 * @param {number} size of icon
 */
const renderEventIcon = (type, size) => {
  switch (type) {
    case true:
      return <Ionicons name="checkmark-circle-outline" size={24} color="black" />;
    case 'opening':
      return <FontAwesome5 name="door-open" size={size} color='black' />
    case 'speaker':
      return <Entypo name="megaphone" size={size} color="black" />
    case 'food':
      return <Ionicons name="fast-food" size={size} color="black" />;
    case 'meeting':
      return <FontAwesome name="group" size={size} color="black" />
    default:
      return <FontAwesome5 name="calendar" size={size} color="black" />
  }
}

/**
 * Returns which icon to represent the type of sponsorship
 * 
 * @param {string} type of sponsorship being rendered
 */
const renderSponsorshipIcon = type => {
  switch (type) {
    case 'Bronze':
      return <MaterialCommunityIcons name="podium-bronze" size={24} color="#cd7f32" />
    case 'Silver':
     return <MaterialCommunityIcons name="podium-silver" size={24} color="#C0C0C0" />
    case 'Gold':
      return <MaterialCommunityIcons name="podium-gold" size={24} color="#FFD700" />
    default:
      return <MaterialCommunityIcons name="border-none-variant" size={24} color="black" />
  }
}

export {
  createAboutIcon,
  createScanQRIcon,
  createScheduleIcon,
  createPresentQRIcon,
  createProfileIcon,
  renderEventIcon,
  renderSponsorshipIcon
};
