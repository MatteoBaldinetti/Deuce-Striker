# Deuce Striker

## Arborescence du projet
```
Assets
├── External Assets
│   └── SkySeries Freebee (Pack gratuit de Skyboxs)
├── Images // Images utilisées dans le projet
│   ├── back.png
│   ├── DeuceStrikerButton.png
│   ├── DeuceStrikerLogo.png
│   ├── PlayButton.png
│   ├── QuitButton.png
│   ├── ScorePanel.png
│   └── SettingsButton.png
├── InputActions
│   └── MenuButton (Input Action Asset) // Script du boutton des menus
├── Maps
│   ├── lowpoly-tennis-stadium (nouvelle map) // Map du terrain de tennis
│   └── tennis-court (ancienne map)
├── Material
│   ├── Hand
│   ├── Red
│   └── TennisBall
├── PhysMaterial
│   └── TennisBall // Physique de la balle
├── Prefabs
│   ├── Racket
│   ├── Target
│   └── TennisBall
├── Samples (Pack pour utiliser XR)
├── Scripts
│   ├── BallSpawnOnOutput.cs // Permet de faire apparaitre et lancer une balle
│   ├── changeHand.cs // Intervertir les mains
│   ├── changeTimeOnLoad.cs // Changer la skybox en fonction du temps choisi
│   ├── Pause.cs // Mettre le jeu en pause
│   ├── ScenesLoader.cs // Changer de scene, c'est un script pour le menu principal
│   ├── ScoreManager.cs // Comme son nom l'indique il permet de gérer les scores et de les afficher
│   ├── Target.cs // Pour gérer les cibles : les détruire et octroyer des points au joueur
│   ├── TargetSpawner.cs // Pour faire apparaître les cibles aléatoirement sur le mur
│   ├── TennisRacket.cs // Toute la gestion de la vitesse de frappe est dans ce script
│   └── TimeChanger.cs // Meme principe que TimeChanger mais pour la scène principal cette fois-ci
├── SFX
│   ├── Musics
│       └── Planet Superstars - Sega Superstars.mp3 // Musique du menu principal
│   ├── Sound Effects
│       └── BallHit.mp3 // Bruit d'impact de la balle sur la raquette
├── TextMeshPro
├── XR
└── XRI
```
