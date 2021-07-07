namespace GamesTan.Tutorial104 {
    public class ItemHealth : Item {
        public int count = 10;
        protected override void OnTriggerTarget(Player player) {
            player.health += count;
        }
    }
}