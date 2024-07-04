<template>
  <q-layout view="hHh lpR fFf">
    <div class="q-pa-md q-ma-md asd full-height" style="max-width: 250px; height: 100%; border-radius: 20px">
      <h4 class="flex flex-center q-pa-none q-ma-none">DormBridge</h4>
      <h6 class="flex flex-center q-pa-none q-ma-none">Bartosz Mroczkowski</h6>
      <h7 class="flex flex-center q-pa-none q-ma-none">Student Account</h7>
      <q-list padding class="rounded-borders text-primary">
        <q-item clickable v-ripple :active="link === 'inbox'" @click="link = 'inbox'" active-class="my-menu-link">
          <q-item-section avatar>
            <q-icon color="white" name="inbox" />
          </q-item-section>
          <q-item-section style="color: white">Inbox</q-item-section>
        </q-item>

        <q-item clickable v-ripple :active="link === 'outbox'" @click="link = 'outbox'" active-class="my-menu-link">
          <q-item-section avatar>
            <q-icon color="white" name="send" />
          </q-item-section>

          <q-item-section style="color: white">Outbox</q-item-section>
        </q-item>

        <q-item clickable v-ripple :active="link === 'trash'" @click="link = 'trash'" active-class="my-menu-link">
          <q-item-section avatar>
            <q-icon color="white" name="delete" />
          </q-item-section>

          <q-item-section style="color: white">Trash</q-item-section>
        </q-item>

        <q-separator spaced />

        <q-item clickable v-ripple :active="link === 'settings'" @click="link = 'settings'" active-class="my-menu-link">
          <q-item-section avatar>
            <q-icon color="white" name="settings" />
          </q-item-section>

          <q-item-section style="color: white">Settings</q-item-section>
        </q-item>

        <q-item clickable v-ripple :active="link === 'help'" @click="link = 'help'" active-class="my-menu-link">
          <q-item-section avatar>
            <q-icon color="white" name="help" />
          </q-item-section>

          <q-item-section style="color: white">Help</q-item-section>
        </q-item>
      </q-list>
    </div>
  </q-layout>
</template>

<script>
import { ref } from 'vue';

export default {
  setup() {
    return {
      link: ref('inbox'),
    };
  },
};
</script>

<style lang="sass">
.my-menu-link
  color: white
  background: #F2C037
</style>

<style lang="sass">
.GPLAY

  &__toolbar
    height: 80px

  &__logo
    width: 183px
    height: 39px

  &__toolbar-input-container
    min-width: 100px
    width: 55%

  &__toolbar-input-btn
    border-radius: 0
    max-width: 60px
    width: 100%

  &__drawer-link

    .q-item__section--avatar
      margin: -8px 0 -8px -16px
      padding: 8px 0 8px 16px

    .q-item__section--main
      margin: -8px -16px -8px 16px
      padding: 8px 16px 8px 2px
      font-size: 18px
      font-weight: 300

    &--apps, &--movies, &--music, &--books, &--devices
      background: #34415f!important
      &:hover
        color: #eee !important

    &--apps:hover
      background: #43a047!important

    &--movies:hover
      background: #e53935!important

    &--music:hover
      background: #fb8c00!important

    &--books:hover
      background: #1e88e5!important

    &--devices:hover
      background: #546e7a!important

  &__drawer-item
    padding: 6px 12px 6px 23px

  &__sticky
    min-height: 49px
    border-bottom: 1px solid rgba(0,0,0,0.12)

  &__sticky-help
    border: 1px solid #ccc
    padding-left: 8px
    padding-right: 8px

  &__sticky-settings
    padding-left: 17px
    padding-right: 17px
    border: 1px solid #ccc
</style>
