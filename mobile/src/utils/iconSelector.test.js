import React from 'react';
import { render } from '@testing-library/react-native';

import {
  createAboutIcon,
  createScanQRIcon,
  createScheduleIcon,
  createPresentQRIcon,
  createProfileIcon,
  renderEventIcon,
  renderSponsorshipIcon
} from '@utils/iconSelector';

describe('iconSelector', () => {
  const focusedProps = {
    color: 'black',
    focused: true
  }
  const unfocusedProps = {
    color: focusedProps.color,
    focused: false
  }

  it('should create the About icon', () => {
    const iconComponentUnfocused = createAboutIcon(unfocusedProps);
    const iconComponentFocused = createAboutIcon(focusedProps);
    expect(iconComponentUnfocused).toBeTruthy();
    expect(iconComponentFocused).toBeTruthy();
  })

  it('should create the Schedule icon', () => {
    const scheduleIconUnfocused = createScheduleIcon(unfocusedProps);
    const scheduleIconFocused = createScheduleIcon(focusedProps);
    expect(scheduleIconUnfocused).toBeTruthy();
    expect(scheduleIconFocused).toBeTruthy();
  })

  it('should create the Profile icon', () => {
    const profileIconUnfocused = createProfileIcon(unfocusedProps);
    const profileIconFocused = createProfileIcon(focusedProps);
    expect(profileIconUnfocused).toBeTruthy();
    expect(profileIconFocused).toBeTruthy();
  })

  it('should create the PresentQR icon', () => {
    const presentQRIconUnfocused = createPresentQRIcon(unfocusedProps);
    const presentQRIconFocused = createPresentQRIcon(focusedProps);
    expect(presentQRIconUnfocused).toBeTruthy();
    expect(presentQRIconFocused).toBeTruthy();
  })
  
  it('should create the ScanQR icon', () => {
    const scanQRIconUnfocused = createScanQRIcon(unfocusedProps);
    const scanQRIconFocused = createScanQRIcon(focusedProps);
    expect(scanQRIconUnfocused).toBeTruthy();
    expect(scanQRIconUnfocused).toBeTruthy();
  })

  it('should render the event icon based on the opening type', () => {
    const openingIcon = renderEventIcon('opening', 24);
    expect(openingIcon.props.name).toBe('door-open');
  })

  it('should render the event icon based on the speaker type', () => {
    const speakerIcon = renderEventIcon('speaker', 24);
    expect(speakerIcon.props.name).toBe('megaphone');
  })

  it('should render the event icon based on the food type', () => {
    const foodIcon = renderEventIcon('food', 24);
    expect(foodIcon.props.name).toBe('fast-food');
  })

  it('should render the event icon based on the meeting type', () => {
    const meetingIcon = renderEventIcon('meeting', 24);
    expect(meetingIcon.props.name).toBe('group');
  })

  it('should render the default event icon if there is no match', () => {
    const calendarIcon = renderEventIcon('test', 24);
    expect(calendarIcon.props.name).toBe('calendar');
  })

  it('should render the sponsorship icon based on the Bronze type', () => {
    const bronzeIcon = renderSponsorshipIcon('Bronze');
    expect(bronzeIcon.props.name).toBe('podium-bronze');
  })

  it('should render the sponsorship icon based on the Silver type', () => {
    const silverIcon = renderSponsorshipIcon('Silver');
    expect(silverIcon.props.name).toBe('podium-silver');
  })

  it('should render the sponsorship icon based on the Gold type', () => {
    const goldIcon = renderSponsorshipIcon('Gold');
    expect(goldIcon.props.name).toBe('podium-gold');
  })

  it('should render the default sponsorship icon if there is no match', () => {
    const defaultSponsorshipIcon = renderSponsorshipIcon('test');
    expect(defaultSponsorshipIcon.props.name).toBe('border-none-variant');
  })
})
