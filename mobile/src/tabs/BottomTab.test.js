import React from 'react';
import { render } from '@testing-library/react-native';

import {
  ScheduleStackScreens,
  ScanQRStackScreens,
  AboutStackScreens,
  AttendeeHome,
  OrganizerHome
} from '@tabs/BottomTab';

describe('BottomTab', () => {

  it('should create the Schedule Stack with 2 screens', () => {
    const scheduleStack = ScheduleStackScreens();
    expect(scheduleStack.props.children.length).toBe(2);
  })

  it('should create the Scan QR Stack with 2 screens', () => {
    const scanQRStack = ScanQRStackScreens();
    expect(scanQRStack.props.children.length).toBe(2);
  })

  it('should create the Scan About Stack with 3 screens', () => {
    const aboutStack = AboutStackScreens();
    expect(aboutStack.props.children.length).toBe(3);
  })

  it('should create the Attendee tab with 4 tabs', () => {
    const attendee = AttendeeHome();
    expect(attendee.props.children.length).toBe(4);
  })

  it('should create the Organizer tab with 3 tabs', () => {
    const organizer = OrganizerHome();
    expect(organizer.props.children.length).toBe(3);
  })
})
