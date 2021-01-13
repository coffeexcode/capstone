import React, { useEffect, useState } from 'react';
import { StyleSheet, SafeAreaView, View, TouchableOpacity } from 'react-native';
import { FontAwesome5 } from '@expo/vector-icons';

import CAText from '@core/CAText';
import CAButton from '@core/CAButton';

import appText from '@utils/text';

import data from '@data/data.json';

/**
 * Returns the Profile screen
 * 
 * @param {object} props.navigation React Navigation navigation obtaining allowing for traversal to different screens
 * 
 * Displays the currently logged in user's contact information as well as the currently loaded conference instance
 */
export default function Profile({ navigation }) {
  const [profileData, setProfileData] = useState({});
  const [instanceData, setInstanceData] = useState({});

  useEffect(() => {
    setProfileData(data["user"][0]);
    setInstanceData(data["instance"][0]);
  }, []);

  const logout = () => navigation.navigate('SignIn');

  return (
    <SafeAreaView style={styles.container}>
      <View style={styles.iconContainer}>
        <FontAwesome5 style={styles.profileIcon} name='user-circle' size={120} color='black' />
      </View>
      <View style={styles.infoContainer}>
        <CAText style={styles.info}>{profileData.name}</CAText>
        <CAText size='md' style={styles.info}>{profileData.email}</CAText>
        <CAText size='md' style={styles.info} appColor>{profileData.phone}</CAText>
      </View>
      <View style={styles.horizontalRule} />
      <View>
        <CAText size='sm' style={styles.description}>
          {appText.conferenceID}
          <CAText size="sm" style={styles.bolded}>
            {instanceData.id}
          </CAText>
        </CAText>
        <CAText size='sm' style={styles.description}>
          {appText.register}
          <CAText size='sm' style={styles.bolded}>
            {instanceData.role}
          </CAText>
        </CAText>
        <CAButton style={styles.loadButton} title={appText.loadNewConferenceTitle} size='sm'/>
        <CAText style={styles.loadMessage} size='xsm'>
            {appText.loadNewConferenceMsg}
          </CAText>
      </View>
      <View style={styles.bottomActionContainer}>
        <CAButton onPress={logout} style={styles.logoutButton} title='Logout' />
      </View>
    </SafeAreaView>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1
  },
  bottomActionContainer: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'flex-end'
  },
  bolded: {
    fontWeight: '400'
  },
  horizontalRule: {
    alignSelf: 'center',
    borderBottomColor: 'black',
    borderBottomWidth: 0.5,
    width: '90%'
  },
  iconContainer: {
    alignSelf: 'center',
    marginTop: 60,
    marginBottom: 20
  },
  info: {
    marginBottom: 10
  },
  description: {
    padding: 10
  },
  infoContainer: {
    alignItems: 'center',
    marginBottom: 10
  },
  loadButton: {
    margin: 30,
    backgroundColor: '#A9A9A9'
  },
  loadMessage: {
    alignSelf: 'center',
    color: '#A9A9A9',
    width: '80%'
  },
  logoutButton: {
    marginBottom: 20,
    width: '90%',
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 5
    },
    shadowOpacity: 0.8,
    shadowRadius: 8,
    elevation: 3
  }
});
