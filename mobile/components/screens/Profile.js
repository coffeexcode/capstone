import React, { useEffect, useState } from 'react';
import { StyleSheet, SafeAreaView, View, TouchableOpacity } from 'react-native';
import { FontAwesome5 } from '@expo/vector-icons';

import CAText from '../core/CAText';
import CAButton from '../core/CAButton';

import mockUserData from '../../assets/testData/user.json';
import mockInstanceData from '../../assets/testData/instance.json';

const text = {
  conferenceID: 'Conference ID: ',
  register: 'You are registered as a(n): ',
  loadNewConference: 'You are using the app with the above conference loaded. You can change this by loading a new conference that you are registered to!'
}
export default function Profile() {
  const [profileData, setProfileData] = useState({});
  const [instanceData, setInstanceData] = useState({});

  useEffect(() => {
    setProfileData(mockUserData[0]);
    setInstanceData(mockInstanceData[0]);
  }, []);

  return (
    <SafeAreaView style={styles.container}>
      <View style={styles.iconContainer}>
        <FontAwesome5 style={styles.profileIcon} name="user-circle" size={120} color="black" />
      </View>
      <View style={styles.infoContainer}>
        <CAText>{profileData.name}</CAText>
        <CAText style={styles.email} size="md">{profileData.email}</CAText>
      </View>
      <View style={styles.horizontalRule} />
      <View style={{ padding: 20 }}>
        <CAText size="sm" style={{ padding: 10 }}>
          {text.conferenceID}
          <CAText size="sm" style={{ fontWeight: '400'}}>
            {instanceData.id}
          </CAText>
        </CAText>
        <CAText size="sm" style={{ padding: 10 }}>
          {text.register}
          <CAText size="sm" style={{ fontWeight: '400'}}>
            {instanceData.role}
          </CAText>
        </CAText>
        <CAButton style={styles.loadButton} title="Load New Conference" size="sm"/>
        <CAText style={{ alignSelf: 'center', color: '#A9A9A9'}} size="xsm">
            {text.loadNewConference}
          </CAText>
      </View>
      <View style={styles.bottomActionContainer}>
        <CAButton style={styles.logoutButton} title="Logout"/>
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
  horizontalRule: {
    alignSelf: 'center',
    borderBottomColor: 'black',
    borderBottomWidth: 0.5,
    width: '90%'
  },
  iconContainer: {
    alignSelf: 'center',
    marginTop: 60,
    marginBottom: 30
  },
  infoContainer: {
    alignItems: 'center',
    marginBottom: 30
  },
  email: {
    color: '#A9A9A9',
    fontWeight: '400'
  },
  loadButton: {
    margin: 30,
    backgroundColor: '#A9A9A9'
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
